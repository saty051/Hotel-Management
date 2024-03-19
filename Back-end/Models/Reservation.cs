using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.Models
{
    public class Reservation
    {
        // ReservationId (Primary Key), RoomId (Foreign Key referencing Room), GuestName, CheckInDate, CheckOutDate

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public string? GuestName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public virtual Room Room { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
