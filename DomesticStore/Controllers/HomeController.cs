using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DomesticStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DomesticStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            if (!db.Categories.Any())
            {
                Category slabs = new Category { Name = "Плиты", Img = "Images/плита.png" };
                Category refrigerators = new Category { Name = "Холодильники", Img = "Images/холодильник.png" };
                Category vacuum = new Category { Name = "Пылесосы", Img = "Images/пылесос.png" };
                Category coffee = new Category { Name = "Кофемашинки", Img = "Images/кофемашина.png" };

                db.Categories.AddRange(slabs, refrigerators, vacuum, coffee);
                db.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Products(int? category, string? name)
        {
            IQueryable<Product> products = db.Products.Include(p => p.Category);
            if (category != null && category != 0)
            {
                products = products.Where(p => p.CategoryId == category);
            }
            if (!string.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name!.Contains(name));
            }
            List<Category> categories = db.Categories.ToList();
            categories.Insert(0, new Category { Name = "Все", Id = 0 });
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = products.ToList(),
                Categories = new SelectList(categories, "Id", "Name", category),
                Name = name
            };
            ViewBag.Result = "";
            return View(viewModel);
        }
        public IActionResult Create()
        {
            ViewBag.Categoies = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Products");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product? product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Products");
                }
            }
            return NotFound();
        }
    }
}
