using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.BLL.DTOs
{
    public class ReservationDTO
    {
        [ValidateNever]
        public int ReservationId { get; set; }

        public int RoomId { get; set; }
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string GuestName { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}
