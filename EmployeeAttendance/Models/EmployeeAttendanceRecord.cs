using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAttendance.Models
{
    public class EmployeeAttendanceRecord
    {
        public int Id { get; set; }
        
        [ValidateNever]
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]    
        public Employee? Employee { get; set; }
        public bool IsPresent { get; set; }
        public DateTime AttendanceDate { get; set; } = DateTime.Now;
    }
}
