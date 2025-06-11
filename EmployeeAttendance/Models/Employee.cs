using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Range(18,60,ErrorMessage ="Age must be between 18 to 60.")]
        public int Age { get; set; }

        [Required(ErrorMessage ="Date of Birth is required.")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage= "Gender is required.")] 
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        public float Salary { get; set; }   

        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }

    }
}
