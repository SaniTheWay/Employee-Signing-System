using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Repositories;
using System.Net;
using System.Runtime.Versioning;

namespace Employee_Signing_System.Services
{
    public class UserService:IUserService
    {
        // DB-Service Injection, using Constructor
        private readonly IUserDbRepository _dbService;
        public UserService(IUserDbRepository dbService)
        {
            _dbService = dbService;
        }

        #region SignIn Search

        /* Search by 'Firstname' and 'Lastname' from EmployeeTable */
        public List<EmployeeStandardVert> signin_search(string fname, string? lname)
        {
            if (string.IsNullOrEmpty(fname) && string.IsNullOrEmpty(lname))
            {
                return null;
            }
            var empList = _dbService.GetList(fname, lname!);
            return empList;
        }

        #endregion

        #region Queue_Request
        /* Make Badge request to the Guard */
        public int queue_req(int id)
        {
            if(id == 0)return (int)HttpStatusCode.BadRequest;

            var q = _dbService.AddTempRecord(id);

            if (q is true)
            {
               
                Console.WriteLine($"User Created with id: {id} in temp table.");
                return (int)HttpStatusCode.Accepted;
            }

            else Console.WriteLine($"User Not Created!");
            return (int)HttpStatusCode.BadRequest;
        }
        #endregion

        #region SignOut
        /* SignOut of the System */
        public int s_SignOut(string badge)
        {
            var q = _dbService.AssignSignOut(badge);
            if (q == false)
            {
                //throw new Exception("Badge Not Found!");
                return (int)HttpStatusCode.NotFound;
            }
            return (int)HttpStatusCode.OK;
        }

        #endregion

    }
}
