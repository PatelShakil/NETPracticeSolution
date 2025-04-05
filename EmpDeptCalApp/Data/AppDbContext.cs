using EmpDeptCalApp.Models;

using Microsoft.EntityFrameworkCore;

namespace EmpDeptCalApp.Data
{
    public class AppDbContext(DbContextOptions op) : DbContext(op)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
