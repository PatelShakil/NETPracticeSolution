using Microsoft.EntityFrameworkCore;
using WebAPIEF.Models;

namespace WebAPIEF.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
