using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementApplication.Models
{
    public class Hotel
    {
        //HotelId (Primary Key),Name,Address,Rating

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }     
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
