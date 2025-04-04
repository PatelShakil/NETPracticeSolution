using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppUI.Models;

namespace WebAppUI.Controllers
{
    public class EmpController : Controller
    {
        private HttpClient client;
        private string baseUrl = "https://localhost:7142/api/Manage";

        public EmpController()
        {
            this.client = new HttpClient();
        }

        public async Task<IActionResult> Index(string? Search)
        {
            if (Search != null)
            {
                var res = await client.GetFromJsonAsync<List<Employee>>(baseUrl + "/Search/" + Search.ToString());
                ViewBag.Search = Search;
                return View(res);
            }


            var result = await client.GetFromJsonAsync<List<Employee>>(baseUrl);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var dept = await client.GetFromJsonAsync<List<Department>>(baseUrl + "/dept");
            ViewData["Departments"] = new SelectList(dept,"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "Salary", "DeptId")] Employee emp)
        {
            var result = await client.PostAsJsonAsync(baseUrl, emp);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await client.GetFromJsonAsync<Employee>(baseUrl + "/" + id.ToString());
            ViewData["Departments"] = new SelectList(await client.GetFromJsonAsync<List<Department>>(baseUrl + "/dept"), "Id", "Name");
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Salary", "DeptId")] Employee emp)
        {
            var result = await client.PutAsJsonAsync(baseUrl + "/" + id.ToString(), emp);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await client.DeleteAsync(baseUrl + "/" + id.ToString());
            return RedirectToAction("Index");
        }
    }
}