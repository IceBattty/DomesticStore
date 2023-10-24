using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomesticStore.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DomesticStore.Controllers
{
    public class PackController : Controller
    {
        ApplicationContext db;
        public PackController(ApplicationContext context)
        {
            db = context;
        }
        [HttpPost]
        public ActionResult Order(int product)
        {

            IQueryable<Product> products = db.Products.Include(p => p.Category);

            products = products.Where(p => p.Id == product);

            OrderViewModel viewModel = new OrderViewModel
            {
                Products = products.ToList()
            };
            return View(viewModel);


        }
        public async Task<IActionResult> Add(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Products", "Home");
        }
    }
}
