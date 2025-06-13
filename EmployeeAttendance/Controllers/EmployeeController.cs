using EmployeeAttendance.Data;
using EmployeeAttendance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAttendance.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            TempData.Remove("Success");
            TempData.Remove("Failure");
            return View();
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Create(Employee? employee)
        {
          if(ModelState.IsValid)

            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                TempData["Success"] = "Employee Created Successfully.";

                return RedirectToAction("Index");

            }
            else
            {
                TempData["Failure"] = "Employee Couldnot Be Created.";
                return View(employee);  
            }
        }
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {

                return RedirectToPage("/Identity/Account/Login");
            }
            else
            {
                IEnumerable<Employee> employees = _context.Employees.Include(e => e.User).ToList();
                
                    return View(employees);
                

               
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }
            Employee? emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if(emp!=null)
            {
                return View(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public IActionResult Edit(Employee? employee)
        {
            if (employee != null)
            {
                if (employee?.Name == null)
                {
                    ModelState.AddModelError("Name", "Name is required");
                }
                if ( employee?.Age == null )

                {
                    ModelState.AddModelError("Age", "Age is required");
                }
                if (employee?.Age < 18 || employee?.Age > 60)
                {
                    ModelState.AddModelError("Age", "Age should be between 18 and 60.");

                }
                if ( employee?.DateOfBirth == null)
                {
                    ModelState.AddModelError("DateOfBirth", "DateOfBirth is required");
                }
                if ( employee.Gender == null)
                {
                    ModelState.AddModelError("Gender", "Gender is required");

                }
                if (employee?.Salary == null)
                {
                    ModelState.AddModelError("Salary", "Gender is required");

                }
            }
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                TempData["UpdateSuccess"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateFailure"] = "Employee Update Failed.";
                return View(employee);
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            Employee? emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
            public IActionResult Delete(Employee? employee)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if(emp == null)
            {
                TempData["DeleteFailure"] = "Employee not Found.";
                return RedirectToAction("Index");

            }
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            TempData["DeleteSuccess"] = "Employee Deleted Successfully.";
            return RedirectToAction("Index");

        }
    }
}
