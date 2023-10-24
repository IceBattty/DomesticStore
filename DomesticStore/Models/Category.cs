using System.Net.Http.Headers;

namespace DomesticStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }

        public List<Product> Products { get; set; }
    }
}
