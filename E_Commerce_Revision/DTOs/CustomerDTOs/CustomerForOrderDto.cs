using E_Commerce_Revision.DTOs.CartDTOs;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.CustomerDTOs
{
    public class CustomerForOrderDto
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public ShoppingCartOnlyDto? ShoppingCartOnly { get; set; }
    }
}
