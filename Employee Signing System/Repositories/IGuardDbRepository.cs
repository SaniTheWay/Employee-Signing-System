using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Repositories
{
    public interface IGuardDbRepository
    {
        IQueryable<EmployeeTempBadge> getBadgeQueue();
        bool AddBadge(int id, string badge, DateTime assignT);
        IQueryable<EmployeeTempBadge> getOutList();
        IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName);
    }
}
