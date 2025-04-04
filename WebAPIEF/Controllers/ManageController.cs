using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIEF.Data;
using WebAPIEF.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController(AppDbContext dbContext) : ControllerBase
    {
        // GET: api/<ManageController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await dbContext.Employees
                .Include(e=>e.Department)
                .ToListAsync();
            return Ok(result);
        }

        // GET: api/<ManageController>
        [HttpGet("dept")]
        public async Task<IActionResult> GetDepartments()
        {
            var result = await dbContext.Departments.ToListAsync();
            return Ok(result);
        }

        // GET api/<ManageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await dbContext.Employees.Include(d =>d.Department)
                .FirstOrDefaultAsync(e=>e.Id ==id);
            return Ok(result);
        }

        // POST api/<ManageController>
        [HttpPost]
        public async Task<IActionResult> Post(Employee value)
        {
            var emp = new Employee();
            emp.Name = value.Name;
            emp.Salary = value.Salary;
            emp.DeptId = value.DeptId ?? null;
            await dbContext.Employees.AddAsync(emp);
            await dbContext.SaveChangesAsync();
            return Ok(emp);
        }

        // PUT api/<ManageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee value)
        {
            var emp = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            emp.Name = value.Name;
            emp.Salary = value.Salary;
            emp.DeptId = value.DeptId;
            dbContext.Employees.Update(emp);
            await dbContext.SaveChangesAsync();
            return Ok(emp);
        }

        // DELETE api/<ManageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            dbContext.Employees.Remove(emp);
            await dbContext.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search(string search)
        {
            var result = await dbContext.Employees.Include(d => d.Department)
                .Where(e => e.Name.Contains(search) || e.Department.Name.Contains(search))
                .ToListAsync();
            return Ok(result);
        }
    }
}
