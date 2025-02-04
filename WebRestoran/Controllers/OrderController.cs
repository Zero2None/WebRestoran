using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebRestoran.Data;
using WebRestoran.Models;


namespace WebRestoran.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepo<Order> _orderRepo;
        private readonly IRepo<OrderItem> _orderItemRepo;
        private readonly IRepo<Food> _foodRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(
            IRepo<Order> orderRepo,
            IRepo<OrderItem> orderItemRepo,
            IRepo<Food> foodRepo,
            IWebHostEnvironment webHostEnvironment,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
            _foodRepo = foodRepo;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _userManager = userManager;
        }
       
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null)
            {
                model = new OrderViewModel
                {
                    OrderItems = new List<OrderItemViewModel>(),
                    Products = await _foodRepo.GetAllAsync()
                };
                HttpContext.Session.Set("OrderViewModel", model);
            }

            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
       

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItem(int prodId, int prodQty)
        {
            var product = await _context.Food.FindAsync(prodId);
            if (product == null)
            {
                return NotFound();
            }

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null)
            {
                model = new OrderViewModel
                {
                    OrderItems = new List<OrderItemViewModel>(),
                    Products = await _foodRepo.GetAllAsync()
                };
            }

            
            var existingItem = model.OrderItems.FirstOrDefault(oi => oi.ProductId == prodId);

            if (existingItem != null)
            {
                existingItem.Quantity += prodQty;
            }
            else
            {
                model.OrderItems.Add(new OrderItemViewModel
                {
                    ProductId = product.FoodId,
                    Price = product.Price,
                    Quantity = prodQty,
                    ProductName = product.FoodName
                });
            }

            // total amount
            model.TotalAmount = model.OrderItems.Sum(oi => oi.Price * oi.Quantity);

            
            HttpContext.Session.Set("OrderViewModel", model);

            return RedirectToAction("Create");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null || model.OrderItems.Count == 0)
            {
                return RedirectToAction("Create");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PlaceOrder()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null || model.OrderItems.Count == 0)
            {
                return RedirectToAction("Create");
            }

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = model.TotalAmount,
                UserId = _userManager.GetUserId(User),
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in model.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    FoodId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                });
            }

            await _orderRepo.AddAsync(order);

            
            HttpContext.Session.Remove("OrderViewModel");

            return RedirectToAction("ViewOrders");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ViewOrders()
        {
            var userId = _userManager.GetUserId(User);

            var userOrders = await _orderRepo.GetAllByIdAsync(userId, "UserId", new QueryOptions<Order>
            {
                Where = o => o.UserId == userId,
                IncludesExpressions = new List<Expression<Func<Order, object>>>
                {
                    o => o.OrderItems,
                    o => o.OrderItems.Select(oi => (object)oi.Food)
                }
            });

            return View(userOrders);
        }

        [HttpPost]
        [Authorize]
        public IActionResult RemoveItem(int prodId)
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model != null)
            {
                model.OrderItems.RemoveAll(oi => oi.ProductId == prodId);
                model.TotalAmount = model.OrderItems.Sum(oi => oi.Price * oi.Quantity);
                HttpContext.Session.Set("OrderViewModel", model);
            }

            return RedirectToAction("Cart");
        }
    }
}
