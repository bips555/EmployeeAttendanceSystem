using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendance.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Date of Birth is required.")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage ="Check the box.")]
        public bool IsActive { get; set; }
        

      


    }
}
