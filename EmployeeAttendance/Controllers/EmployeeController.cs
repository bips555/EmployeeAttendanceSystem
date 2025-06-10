using EmployeeAttendance.Data;
using EmployeeAttendance.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAttendance.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            TempData.Remove("Success");
            TempData.Remove("Failure");
            return View();
        }
        [HttpPost]
        public IActionResult Create( Employee? employee)
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
            IEnumerable<Employee> employees = _context.Employees.ToList();
            if(employees!= null)
            {
                return View(employees);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id <= 0)
            {
                return NotFound();
            }
            Employee emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if(emp!=null)
            {
                return View(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Employee? employee)
        {
            if(employee==null && employee?.Name==null)
            {
                ModelState.AddModelError("Name","Name is required");
            }
            if (employee == null && employee?.Age == null)
            {
                ModelState.AddModelError("Age", "Age is required");
            }
            if (employee == null && employee?.DateOfBirth == null)
            {
                ModelState.AddModelError("DateOfBirth", "DateOfBirth is required");
            }
            if (employee == null && employee.Gender == null)
            {
                ModelState.AddModelError("Gender", "Gender is required");

            }
            if (employee == null && employee?.Salary == null)
            {
                ModelState.AddModelError("Salary", "Gender is required");

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
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            Employee emp = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(Employee? employee)
        {
            TempData["DeleteSuccess"] = "Employee Deleted Successfully.";
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
          
        }
    }
}
