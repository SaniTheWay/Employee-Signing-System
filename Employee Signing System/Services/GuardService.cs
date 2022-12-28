using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Models.ViewModel;
using Employee_Signing_System.Repositories;
using System.Net;

namespace Employee_Signing_System.Services
{
    public class GuardService:IGuardService
    {
        private readonly IGuardDbRepository _db;
        public GuardService(IGuardDbRepository dbService)
        {
            _db = dbService;
        }

        public IQueryable<GuardQueue> BadgeQueue()
        {
            var queue = _db.getBadgeQueue();
            return queue;
        }

        public int AssignBadge(int UId, string badge, DateTime assignT)
        {
            var q = _db.AddBadge(UId, badge,assignT);
            if (!q)
            {
                return (int)HttpStatusCode.Conflict;
            }
            return  (int)HttpStatusCode.Accepted;
        }

        public IQueryable<GuardQueue> s_OutList()
        {
            var q = _db.getOutList();
            return q;
        }

        public IQueryable<EmployeeTempBadge> GetReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName)
        {
            var q = _db.getReport(sDate, eDate, fName, lName);
            return q;
        }
    }
}