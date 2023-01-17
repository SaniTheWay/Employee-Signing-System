using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Models.ViewModel;

namespace Employee_Signing_System.Repositories
{
    public class GuardDbRepository:IGuardDbRepository
    {
        private readonly EmployeeSigningSystemContext _db;

        public GuardDbRepository()
        {
            _db = new EmployeeSigningSystemContext();
        }
        public GuardDbRepository(EmployeeSigningSystemContext dbContext)
        {
            _db = dbContext;
        }

        #region Get Queue

        public IQueryable<GuardQueue> getBadgeQueue()
        {
            /* List all requests with Assign Time -> 'null' in TempBadge Table */

            //var q = _db.EmployeeTempBadges.Where(e=> e.AssignT == null);
            var q = _db.EmployeeTempBadges.Join(_db.EmployeeStandardVerts,
                                                s => s.EmpId, t => t.Id,
                                                (s,t)=> new GuardQueue
                                                {
                                                    TempEmployee = s,
                                                    TempEmpImg = t.PhotoUrl!
                                                }                                               
                                                ).Where(e => e.TempEmployee.AssignT == null);
            return q;
        }

        #endregion

        #region Add Badge
        private bool isValid_Badge(string badge)
        {
    /*      check weather this assigned badge is valid or not
    *       i.e., Unique in fields having SignOutT == 'null' 
    */
            var q = _db.EmployeeTempBadges.Where(e => e.SignOutT == null && e.TempBadge == badge);
            Console.WriteLine($"Employees with similar badge: {q.Count()}");
            if(q.Count() > 0)
            {
                Console.WriteLine("Badge Already Assigned!");
                return false;
            }
            return true;
        }
        public bool AddBadge(int id, string badge, DateTime assignT)
        {
            //if (!isValid_Badge(badge)) throw new Exception("Badge Already Assigned!"); return false;
            if (!isValid_Badge(badge)) return false;

            //Find tempEmp by 'id'
            var temp_record = _db.EmployeeTempBadges.Find(id);

            //if (temp_record == null){ throw new Exception("Record Not Found."); }
            if (temp_record == null){return false;}

            temp_record.AssignT = assignT;
            temp_record.TempBadge = badge;

            Save();
            return true;
        }

        public IQueryable<GuardQueue> getOutList()
        {
            //var q = _db.EmployeeTempBadges.Where(e => e.AssignT != null && e.SignOutT==null);

            var q = _db.EmployeeTempBadges.Join(_db.EmployeeStandardVerts,
                                                s => s.EmpId, t => t.Id,
                                                (s, t) => new GuardQueue
                                                {
                                                    TempEmployee = s,
                                                    TempEmpImg = t.PhotoUrl!
                                                }
                                                );
            q = q.Where(e => e.TempEmployee.AssignT != null && e.TempEmployee.SignOutT == null);

            return q;
        }

        public IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName)
        {

            #region Nesting SQL Queries
            /*
             * for big data, we use to specify the data for easy searching
             * The search then only be done over that data (where, 'var q' initializing)
             * 
             * Here we are nesting the query one after another by using if statements
             */

            IQueryable<EmployeeTempBadge> q = _db.EmployeeTempBadges.Where(x => x.EmployeeFirstName != null);

            if (!string.IsNullOrEmpty(fName))
            {
                q = q.Where(e => e.EmployeeFirstName.Contains(fName));
            }
            if (!string.IsNullOrEmpty(lName))
            {
                q = q.Where(e => e.EmployeeLastName.Contains(lName));
            }
            if(!(sDate == DateTime.MinValue))
            {
                q = q.Where(e => e.SignInT.Date >= sDate.Date);
            }
            if (!(eDate == DateTime.MinValue))
            {
                q = q.Where(e => e.SignInT.Date <= eDate.Date);
            }

            #endregion

            #region No Nesting

            //if (fName == null && lName == null)
            //{
            //    q = _db.EmployeeTempBadges.Where(e =>
            //    e.SignInT.Date >= sDate && e.SignInT.Date <= eDate);
            //}
            //else
            //{
            //    q = _db.EmployeeTempBadges.Where(e =>
            //    e.SignInT.Date >= sDate && e.SignInT.Date <= eDate
            //    && (e.EmployeeFirstName.Contains(fName) || e.EmployeeLastName.Contains(lName)));
            //}
            #endregion


            return q;
        }
        #endregion

        private void Save()
        {
            _db.SaveChanges();
        }
    }
}
