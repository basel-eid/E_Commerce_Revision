using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumberOfItems { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
