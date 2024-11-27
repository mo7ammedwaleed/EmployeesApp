using EmployeesApp.Data;
using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Controllers
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string sortField, string currentSortField, SortDirection sortDirection, string searchByName)
        {
            var employees = GetEmployees();
            if (!string.IsNullOrEmpty(searchByName))
                employees = employees.Where(e => e.EmployeeName.ToLower().Contains(searchByName.ToLower())).ToList();
            return View(this.SortEmployees(employees, sortField, currentSortField, sortDirection));
        }

        private List<Employee> GetEmployees()
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

            return employees;
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

        public IActionResult Delete(int id)
        {
            Employee emp = this._context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private List<Employee> SortEmployees(List<Employee> employees, string sortField, string currentSortField, SortDirection sortDirection)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "EmployeeNumber";
                ViewBag.SortDirection = SortDirection.Ascending;
            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.SortDirection = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                else
                    ViewBag.SortDirection = SortDirection.Ascending;
                ViewBag.SortField = sortField;
            }

            var propertyInfo = typeof(Employee).GetProperty(ViewBag.SortField);
            if(ViewBag.SortDirection == SortDirection.Ascending)
                employees = employees.OrderBy(e => propertyInfo.GetValue(e,null)).ToList();
            return employees;


        }

    }
}
