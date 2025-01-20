﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Revision.DTOs.CustomerDTOs
{
    public class CustomerForShoppingDto
    {
        [Required]
        public string Name { get; set; }
        [Phone]
        public string Contact { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public IList<OrderOnlyDto> orderOnlyDtos { get; set; }
    }
}
