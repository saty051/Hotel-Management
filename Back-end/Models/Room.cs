using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.Models
{
    public class Room
    {
        // RoomId (Primary Key),HotelId (Foreign Key referencing Hotel),RoomNumber,Capacity

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
