using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.Models
{
    public class Employee
    {
        // EmployeeId (Primary Key), HotelId (Foreign Key referencing Hotel), FirstNam, LastName, Position 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public int HotelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
