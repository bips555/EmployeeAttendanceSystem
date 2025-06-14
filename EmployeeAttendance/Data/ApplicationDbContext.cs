﻿using EmployeeAttendance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
       public DbSet<Employee> Employees { get; set; }
      public DbSet<EmployeeAttendanceRecord> EmployeeAttendanceRecords { get; set; }
    }
}
