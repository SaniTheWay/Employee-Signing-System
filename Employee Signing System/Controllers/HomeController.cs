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

        // Employee Sign In Page 
        #region Employee SignIn

        // to get List after Search by 'FName' and 'LName'

        [HttpGet]
        public IActionResult Get_EmpList(string fname, string? lname)
        {
            var list = _userService.signin_search(fname, lname);
            if(list == null)
                ViewBag.status = (int)HttpStatusCode.NotAcceptable;
            return View("Index",list.AsEnumerable());
        }

        // Employee Submit request 

        [HttpPost]
        public IActionResult Emp_EnQueue(int imgId)
        {
            //Console.WriteLine("Selected ImageId : "+imgId);
            ViewBag.status = _userService.queue_req(imgId);
            return View("Index");
        }
        #endregion

        // Employee SignOut
        #region Employee SignOut

        public ActionResult SignOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignOut(string badge)
        {
            var q = _userService.s_SignOut(badge);
            ViewBag.status = q;
            return View("Index");
        }
        #endregion
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