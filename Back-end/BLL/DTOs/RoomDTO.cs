using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.BLL.DTOs
{
    public class RoomDTO
    {
        [ValidateNever]
        public int RoomId { get; set; }
        public int hotelId { get; set; }
        [Required(ErrorMessage ="RoomNumber is required")]
        [StringLength(10)]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage ="Capacity is required")]
        public int Capacity { get; set; }
        [Required(ErrorMessage ="Price is required")]
        public decimal Price { get; set; }
    }
}
