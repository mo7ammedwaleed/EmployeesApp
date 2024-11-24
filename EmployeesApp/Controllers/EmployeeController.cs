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
            var employees = (from employee in _context.Employees
                             join department in _context.Departments
                             on employee.DepartmentId equals department.DepartmentId
                             select new Employee
                             {
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeNumber = employee.EmployeeNumber,
                                 BirthDate = employee.BirthDate,
                                 HiringDate = employee.HiringDate,
                                 GrossSalary = employee.GrossSalary,
                                 NetSalary = employee.NetSalary,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = department.DepartmentName,
                             }).ToList();

            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = this._context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this._context.Departments.ToList();
            return View();
        }
        public IActionResult Edit(int id)
        {
            Employee emp = this._context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            ViewBag.Departments = this._context.Departments.ToList();
            return View("Create",emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                _context.Employees.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this._context.Departments.ToList();
            return View("Create",model);
        }

    }
}
