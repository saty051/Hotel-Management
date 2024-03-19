using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.BLL.DTOs
{
    public class CustomerDTO
    {
       public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength (50)]
        public string LastName { get; set; }
        [Required]
        [StringLength (100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength (50)]
        public string Phone { get; set; }
    }
}
