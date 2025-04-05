using System.Diagnostics;

using EventDelegateLoggerWebApp.Models;
using EventDelegateLoggerWebApp.Utils;

using Microsoft.AspNetCore.Mvc;

namespace EventDelegateLoggerWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Events events;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            events = new Events();
        }

        public IActionResult Index()
        {
            events.OnLoad += (pageName) =>
            {
                Console.WriteLine("EVENT ON LOAD CALLED IMPLEMENTATION GOES HERE");
            };  

            try
            {
                events.EventLoad("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
