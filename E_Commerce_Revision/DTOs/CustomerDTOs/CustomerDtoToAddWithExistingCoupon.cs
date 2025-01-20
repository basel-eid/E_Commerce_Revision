using E_Commerce_Revision.DTOs.CartDTOs;
using E_Commerce_Revision.DTOs.OrderDTOs;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace E_Commerce_Revision.DTOs.CustomerDTOs
{
    public class CustomerDtoToAddWithExistingCoupon
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ShoppingCartOnlyDto ShoppingCartOnlyDto { get; set; }
        public IList<OrderForCustomerDto> orderForCustomerDtos { get; set; }
        public int CouponId { get; set;}
    }
}
