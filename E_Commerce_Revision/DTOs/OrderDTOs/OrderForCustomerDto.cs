using E_Commerce_Revision.DTOs.ProductDTOs;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.OrderDTOs
{
    public class OrderForCustomerDto
    {
        [Required]
        public int Price { get; set; }
        public IList<ProductsOnlyDto> ProductsOnly { get; set; }
    }
}
