using System.ComponentModel.DataAnnotations;

namespace DomesticStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public int ProductId { get; set; }
    }
}
