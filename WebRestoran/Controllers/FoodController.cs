using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Data;
using WebRestoran.Models;

namespace WebRestoran.Controllers
{
    public class FoodController : Controller
    {
        private readonly IRepo<Food> _foodRepo;
        private readonly IRepo<Ingredient> _ingredientRepo;
        private readonly IRepo<Category> _categoryRepo;
        private readonly IRepo<FoodIngredient> _foodIngredientRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        public FoodController(
            IRepo<Food> foodRepo,
            IRepo<Ingredient> ingredientRepo,
            IRepo<Category> categoryRepo,
            IRepo<FoodIngredient> foodIngredientRepo,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext context)
        {
            _foodRepo = foodRepo;
            _ingredientRepo = ingredientRepo;
            _categoryRepo = categoryRepo;
            _foodIngredientRepo = foodIngredientRepo;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var foodList = await _foodRepo.GetAllAsync();
            return View(foodList);
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Ingredients = await _ingredientRepo.GetAllAsync();
            ViewBag.Categories = await _categoryRepo.GetAllAsync();

            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Food());
            }
            else
            {
                //string
                var product = await _foodRepo.GetByIdAsync(id, new QueryOptions<Food> { Includes = "FoodIngredients.Ingredient, Category" });

                if (product == null)
                {
                    return NotFound();
                }

                ViewBag.Operation = "Edit";
                return View(product);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(Food product, int[] ingredientIds, int catId)
        {
            ViewBag.Ingredients = await _ingredientRepo.GetAllAsync();
            ViewBag.Categories = await _categoryRepo.GetAllAsync();

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (ingredientIds == null || ingredientIds.Length == 0)
            {
                ModelState.AddModelError("Ingredients", "At least one ingredient must be selected.");
                return View(product);
            }

            // Image Upload
            if (product.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                int retryCount = 3;
                while (retryCount > 0)
                {
                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await product.ImageFile.CopyToAsync(fileStream);
                        }
                        break; // Exit loop if successful
                    }
                    catch (IOException)
                    {
                        retryCount--;
                        if (retryCount == 0) throw; // Rethrow exception if retries are exhausted
                        await Task.Delay(1000); // Wait for 1 second before retrying
                    }
                }
                
                product.ImageUrl = uniqueFileName;
                await _foodRepo.UpdateAsync(product);
                await _context.SaveChangesAsync();
            }

            if (product.FoodId == 0)
            {
                if (catId == 0)
                {
                    ModelState.AddModelError("CategoryId", "Please select a category.");
                    return View(product);
                }
                product.CategoryId = catId;
               
                await _foodRepo.AddAsync(product);
                await _context.SaveChangesAsync(); 

                foreach (int ingredientId in ingredientIds)
                {
                    var foodIngredient = new FoodIngredient
                    {
                        FoodId = product.FoodId,
                        IngredientId = ingredientId
                    };
                    await _foodIngredientRepo.AddAsync(foodIngredient);
                }
                await _context.SaveChangesAsync();

            }
            else
            {
                var existingProduct = await _foodRepo.GetByIdAsync(product.FoodId, new QueryOptions<Food> { Includes = "FoodIngredients" });

                if (existingProduct == null)
                {
                    ModelState.AddModelError("", "Product not found.");
                    ViewBag.Ingredients = await _ingredientRepo.GetAllAsync();
                    ViewBag.Categories = await _categoryRepo.GetAllAsync();
                    return View(product);
                }

                existingProduct.FoodName = product.FoodName;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.CategoryId = catId;

                //ukloni stare sastojke
                foreach (var fi in existingProduct.FoodIngredients.ToList())
                {
                    _context.Set<FoodIngredient>().Remove(fi);
                }
                await _context.SaveChangesAsync();

                existingProduct.FoodIngredients?.Clear();
                
                foreach (int id in ingredientIds)
                {
                    await _foodIngredientRepo.AddAsync(new FoodIngredient { IngredientId = id, FoodId = product.FoodId });
                }
                await _context.SaveChangesAsync();

                try
                {
                    await _foodRepo.UpdateAsync(existingProduct);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.GetBaseException().Message}");
                    ViewBag.Ingredients = await _ingredientRepo.GetAllAsync();
                    ViewBag.Categories = await _categoryRepo.GetAllAsync();
                    return View(product);
                }
            }

            return RedirectToAction("Index", "Food");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _foodRepo.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Product not found.");
                return RedirectToAction("Index");
            }
        }
    }
}
