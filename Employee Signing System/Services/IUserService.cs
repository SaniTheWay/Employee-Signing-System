using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Services
{
    public interface IUserService
    {
        List<EmployeeStandardVert> signin_search(string fname, string? lname);
    }
}
