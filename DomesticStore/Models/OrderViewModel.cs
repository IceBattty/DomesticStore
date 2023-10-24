using System.Collections;

namespace DomesticStore.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public Order Order { get; set; } = new Order();

    }
}
