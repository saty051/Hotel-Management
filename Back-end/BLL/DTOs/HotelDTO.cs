using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.BLL.DTOs
{
        public class HotelDTO
    {
        [ValidateNever]
            public int HotelId { get; set; }
        [Required(ErrorMessage ="Hotel name is required")]
            public string Name { get; set; }
        [Required(ErrorMessage ="Address is required")]
        [StringLength(100)]
            public string Address { get; set; }
            public decimal Rating { get; set; }
        }
}
