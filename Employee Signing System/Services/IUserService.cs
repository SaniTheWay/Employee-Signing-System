using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Services
{
    public interface IUserService
    {
        public List<EmployeeStandardVert> signin_search(string fname, string? lname);
        public int queue_req(int id);
         public int s_SignOut(string badge);
    }
}
