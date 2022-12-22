using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Repositories
{
    public interface IUserDbRepository
    {
        List<EmployeeStandardVert> GetList(string fname, string lname);
        bool AddTempRecord(int id);
        bool AssignSignOut(string badge);
    }
}
