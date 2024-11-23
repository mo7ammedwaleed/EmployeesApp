using Microsoft.EntityFrameworkCore;
using EmployeesApp.Models;

namespace EmployeesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=MOHAMMED-WALEED\SQLEXPRESS;Database=EmployeesApp;Integrated Security=True;Trust Server Certificate=True;");
        }
    }
}
