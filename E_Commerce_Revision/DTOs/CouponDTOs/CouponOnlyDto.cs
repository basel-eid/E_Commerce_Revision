using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.CouponDTOs
{
    public class CouponOnlyDto
    {
        [Required]
        public string Title { get; set; }
        public string Percentage { get; set; }
    }
}
