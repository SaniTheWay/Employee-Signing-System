using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Models.ViewModel;

namespace Employee_Signing_System.Services
{
    public interface IGuardService
    {
        IQueryable<GuardQueue> BadgeQueue();
        int AssignBadge(int UId, string badge, DateTime assignT);
        IQueryable<GuardQueue> s_OutList();
        IQueryable<EmployeeTempBadge> GetReport(DateTime sDate, DateTime eDate, string? fName, string? lName);
    }
}
