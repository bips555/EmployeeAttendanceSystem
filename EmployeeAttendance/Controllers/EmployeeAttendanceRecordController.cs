using EmployeeAttendance.Data;
using EmployeeAttendance.Models;
using EmployeeAttendance.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Controllers
{
    [Authorize]
    public class EmployeeAttendanceRecordController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeAttendanceRecordController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var attendanceRecords = _context.EmployeeAttendanceRecords.Include(e => e.Employee).OrderByDescending(e=>e.Id).ToList();   
            return View(attendanceRecords);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult TakeAttendance()
        {
            var today = DateTime.Today.Date;
            var employees = _context.Employees.Include(e => e.User).ToList();
            var existingCurrentAttendance = _context.EmployeeAttendanceRecords.Where(e => e.AttendanceDate == today).ToList();
            var records = employees.Select(e => new EmployeeAttendanceRecordsVM()
            {
                EmployeeId = e.Id,
                EmployeeName = e.Name,
                IsPresent = existingCurrentAttendance.FirstOrDefault(a => a.EmployeeId == e.Id)?.IsPresent ?? false
            }).ToList();
            ViewBag.AttendanceDate = today.ToString("yyyy-MM-dd");  
            return View(records);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult TakeAttendance(List<EmployeeAttendanceRecordsVM> employeeAttendanceRecordsVM, string attendanceDate)
        {
            if (ModelState.IsValid)
            {
                var date = DateTime.Parse(attendanceDate).Date;
                var existingAttendance = _context.EmployeeAttendanceRecords.Where(e => e.AttendanceDate == date).ToList();

                foreach (var record in employeeAttendanceRecordsVM)
                {
                    var existingRecord = existingAttendance.FirstOrDefault(e => e.EmployeeId == record.EmployeeId);
                    if (existingRecord != null)
                    {
                        existingRecord.IsPresent = record.IsPresent;
                        _context.EmployeeAttendanceRecords.Update(existingRecord);
                    }
                    else
                    {
                        var newRecord = new EmployeeAttendanceRecord()
                        {
                            EmployeeId = record.EmployeeId,
                            IsPresent = record.IsPresent,
                            AttendanceDate = date
                        };
                        _context.EmployeeAttendanceRecords.Add(newRecord);
                    }
                    
                }
               _context.SaveChanges();
                TempData["AttendanceSuccess"] = "Attendance records updated successfully."; 
                return RedirectToAction("Index");

            }
            else
            {
                TempData["AttendanceFailure"] = "Failed to update attendance records. Please try again.";
                return View(employeeAttendanceRecordsVM);
            }
        }
           
        }
       
    }


