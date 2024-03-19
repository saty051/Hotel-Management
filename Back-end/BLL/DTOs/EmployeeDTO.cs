using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementApplication.BLL.DTOs
{
    public class EmployeeDTO
    {
        [ValidateNever]
        public int EmployeeId { get; set; }

        public int HotelId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Position { get; set; }

    }
}
