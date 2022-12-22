using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Services
{
    public interface IGuardService
    {
        IQueryable<EmployeeTempBadge> BadgeQueue();
        int AssignBadge(int UId, string badge, DateTime assignT);
        IQueryable<EmployeeTempBadge> s_OutList();
        IQueryable<EmployeeTempBadge> GetReport(DateTime sDate, DateTime eDate, string? fName, string? lName);
    }
}
