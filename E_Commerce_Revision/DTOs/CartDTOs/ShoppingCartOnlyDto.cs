using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.CartDTOs
{
    public class ShoppingCartOnlyDto
    {
        [Required]
        public int NumberOfItems { get; set; }
    }
}
