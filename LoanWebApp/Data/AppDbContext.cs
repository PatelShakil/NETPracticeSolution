using LoanWebApp.Models;

using Microsoft.EntityFrameworkCore;

namespace LoanWebApp.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Loan> Loans { get; set; }
    }
}
