using System.ComponentModel.DataAnnotations;

namespace DomesticStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Img { get; set; }
        [Required]
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
