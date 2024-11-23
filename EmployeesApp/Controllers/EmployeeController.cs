using EmployeesApp.Data;
using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            List<Employee> employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
