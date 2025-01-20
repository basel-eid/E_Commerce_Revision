using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Percentage { get; set; }
        public IList<Customer>? Customers { get; set; }
    }
}
