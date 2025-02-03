using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRestoran.Data;
using WebRestoran.Models;

namespace WebRestoran.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredientData { get; set; }
        public IngredientController(ApplicationDbContext ctx) => ingredientData = new Repository<Ingredient>(ctx);    //constructor injection- injects the db context into the controller

        public async Task<IActionResult> Index()
        {
            var data = await ingredientData.GetAllAsync(); //fetches data asynchronously
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await ingredientData.GetByIdAsync(id, new QueryOptions<Ingredient>() {Includes="FoodIngredients.Food" });
            return View(data);
        }

        //dodavanje novog sastojka
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId", "IngredientName")]Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await ingredientData.AddAsync(ingredient);
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ingredient = await ingredientData.GetByIdAsync(id, new QueryOptions<Ingredient> { Includes = "FoodIngredients.Food" });
            if (ingredient == null) return NotFound();
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await ingredientData.UpdateAsync(ingredient);
                return RedirectToAction(nameof(Index));
            }

            return View(ingredient);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = await ingredientData.GetByIdAsync(id, new QueryOptions<Ingredient> {Includes="FoodIngredients.Food" });
            if (ingredient == null) return NotFound();
            return View(ingredient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ingredientData.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
