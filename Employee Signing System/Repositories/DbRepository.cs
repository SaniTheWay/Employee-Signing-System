using Employee_Signing_System.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Employee_Signing_System.Repositories
{
    public class DbRepository:IDbRepository
    {
        EmployeeSigningSystemContext _db;
        public DbRepository()
        {
            _db = new EmployeeSigningSystemContext();
        }
        public DbRepository(EmployeeSigningSystemContext dbContext)
        {
            _db = dbContext;
        }
        public List<EmployeeStandardVert> GetList(string fname, string? lname)
        {
            var empList = _db.EmployeeStandardVerts.Where(q => 
                            q.EFirstName == fname || q.ELastName==lname)
                                .ToList();
            return empList;
        }

    }
}
