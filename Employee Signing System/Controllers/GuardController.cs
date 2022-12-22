using Employee_Signing_System.Models.ViewModel;
using Employee_Signing_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using System.Reflection.Metadata;

namespace Employee_Signing_System.Controllers
{
    public class GuardController : Controller
    {
        private readonly IGuardService _service;
        public GuardController(IGuardService service)
        {
            _service = service;
        }
        // GET: GuardController
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult Queue()
        {
            GuardQueue model = new GuardQueue()
            {
                TempEmployee = _service.BadgeQueue().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Queue(int UId, string badge, DateTime assignTime)
        {
            var status = _service.AssignBadge(UId, badge, assignTime);            
            ViewBag.status = status;
            //return RedirectToAction("Queue");
            //return Redirect("Queue");
            return View("Queue");
        }

        public ActionResult BadgeOut()
        {
            GuardOut model = new GuardOut()
            {
                TempEmpRecord = _service.s_OutList().ToList()
            };
            return View(model);
        }

        public ActionResult BadgeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BadgeReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName)
        {

            var model = _service.GetReport(sDate, eDate, fName, lName);
            return View(model);
        }

    }
}
