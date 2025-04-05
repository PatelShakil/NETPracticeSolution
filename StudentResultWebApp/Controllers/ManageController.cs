using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using StudentResultWebApp.Models;

namespace StudentResultWebApp.Controllers
{
    public class ManageController : Controller
    {
        public HttpClient client = new HttpClient();
        public String baseUrl = "https://localhost:7172/api/Student/"; 
        public async Task<IActionResult> Index()
        {
            var result = await client.GetFromJsonAsync<List<Student>>(baseUrl + "get-all");
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,RollNo")] Student std)
        {
            if (ModelState.IsValid)
            {
                var res = await client.PostAsJsonAsync<Student>(baseUrl + "add", std);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            var res = await client.GetFromJsonAsync<Student>(baseUrl + "find/" + id.ToString());
            return View(res);
        }

        public async Task<IActionResult> AssignSem(int id)
        {
            var sems = await client.GetFromJsonAsync<List<Semester>>(baseUrl + "get-semesters/MSCICT");
            ViewData["semesters"] = new SelectList(sems, "Id", "Name");
            var std = await client.GetFromJsonAsync<Student>(baseUrl + "find/" + id.ToString());
            return View(std);
        }
        [HttpPost]
        public async Task<IActionResult> AssignSem([Bind("Id","SemId")] StdSem stdSem)
        {
            if (ModelState.IsValid)
            {
                await client.GetAsync(baseUrl + "std-sem/"+stdSem.Id + "/" + stdSem.SemId);
            }
            return RedirectToAction("Detail",stdSem.Id);
        }

        public Task<IActionResult> AssignSubject()
        {
            return View();
        }

    }
}
