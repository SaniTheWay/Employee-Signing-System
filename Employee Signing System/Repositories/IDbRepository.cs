using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Repositories
{
    public interface IDbRepository
    {
        List<EmployeeStandardVert> GetList(string fname, string lname);
    }
}
