using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
        public IList<Product>? Products { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
