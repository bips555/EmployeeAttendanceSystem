using EmployeeAttendance.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
       public DbSet<Employee> Employees { get; set; }
      public DbSet<EmployeeAttendanceRecord> EmployeeAttendanceRecords { get; set; }
    }
}
