using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Models.ViewModel;

namespace Employee_Signing_System.Repositories
{
    public interface IGuardDbRepository
    {
        IQueryable<GuardQueue> getBadgeQueue();
        bool AddBadge(int id, string badge, DateTime assignT);
        IQueryable<GuardQueue> getOutList();
        IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName);
    }
}
