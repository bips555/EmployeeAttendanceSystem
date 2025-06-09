using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
    }
}
