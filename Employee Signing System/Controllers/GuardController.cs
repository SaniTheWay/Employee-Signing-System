using Employee_Signing_System.Models.ViewModel;
using Employee_Signing_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        #region Queue


        // Queue Requests created by Employee
        [Authorize]
        public ActionResult Queue()
        {
            ViewBag.status = TempData["status"];
            var model = _service.BadgeQueue().ToList();
            //GuardQueue model = new GuardQueue()
            //{
            //    TempEmployee = _service.BadgeQueue().ToList()
            //};
            return View(model);
        }

        // Assign Badge to the Employee with AssignTime
        [HttpPost]
        [Authorize]
        public ActionResult Queue(int UId, string badge, DateTime assignTime)
        {
            var status = _service.AssignBadge(UId, badge, assignTime);
            TempData["status"] = status;
            return RedirectToAction("Queue");
            //return Redirect("Queue");
            //return View("Queue");
        }
        #endregion


        [Authorize]
        public ActionResult BadgeOut()
        {
            var model = _service.s_OutList().ToList();
            //GuardOut model = new GuardOut()
            //{
            //    TempEmpRecord = _service.s_OutList().ToList()
            //};
            return View(model);
        }

        [Authorize]
        public ActionResult BadgeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BadgeReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName)
        {
            //Check for SQL Error

            /*if(sDate==DateTime.MinValue)
            {
                string dateInput = "Jan 1, 2022";
                sDate = DateTime.Parse(dateInput);
            }
            if(eDate==DateTime.MinValue){ eDate = DateTime.Now; } */

            var model = _service.GetReport(sDate, eDate, fName, lName);

            return View(model);
         }

    }
}
