using Employee_Signing_System.Models;
using Employee_Signing_System.Models.ViewModel;
using Employee_Signing_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Employee_Signing_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get_EmpList(string fname, string? lname)
        {
            var list = _userService.signin_search(fname, lname);
            return View("Index",list.AsEnumerable());
        }

        [HttpPost]
        public IActionResult Emp_EnQueue(id)
        {
            if(ReqEnqueue(id))
                ViewBag.status = HttpStatusCode.Accepted;
            return View("Index");
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