using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.Models
{
    public class Customer
    {
        // CustomerId(Primary Key), FirstName, LastName, Email, Phone

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
