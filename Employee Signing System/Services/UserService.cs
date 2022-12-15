using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Repositories;
using System.Runtime.Versioning;

namespace Employee_Signing_System.Services
{
    public class UserService:IUserService
    {
        private readonly IDbRepository _dbService;
        public UserService(IDbRepository dbService)
        {
            _dbService = dbService;
        }

        public List<EmployeeStandardVert> signin_search(string fname, string? lname)
        {
            var empList = _dbService.GetList(fname, lname!);
            return empList;
        }
    }
}
