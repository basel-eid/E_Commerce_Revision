using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.ProductDTOs
{
    public class ProductsOnlyDto
    {
        [Required]
        public string? Name { get; set; }
        [MaxLength(100, ErrorMessage = "Max length is 100")]
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
    }
}
