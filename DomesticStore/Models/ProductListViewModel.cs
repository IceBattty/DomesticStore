using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DomesticStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public SelectList Categories { get; set; } = new SelectList(new List<Category>(), "Id", "Name");
        public string? Name { get; set; }
    }
}
