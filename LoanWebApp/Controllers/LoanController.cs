using LoanWebApp.Data;
using LoanWebApp.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LoanWebApp.Controllers
{
    public class LoanController(AppDbContext dbContext) : Controller
    {
        private String baseUrl = "https://localhost:7299/api/Loan";
        private HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {

            return View(await dbContext.Loans.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CustomerName,Gender,PrincipalAmount,NoOfYears")] Loan loan)
        {

            if (ModelState.IsValid)
            {
                var InterestRate = await client.GetFromJsonAsync<double>($"{baseUrl}/interest-rate/{loan.Gender}");
                var InterestAmount = await client.GetFromJsonAsync<double>($"{baseUrl}/interest-amount/{loan.PrincipalAmount}/{loan.NoOfYears}/{InterestRate}");

                loan.InterestAmount = InterestAmount;
                loan.InterestRate = InterestRate;
                await dbContext.AddAsync(loan);
                await dbContext.SaveChangesAsync();
            }
                return RedirectToAction("Index");
        }
    }
}
