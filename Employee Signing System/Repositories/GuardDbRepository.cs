﻿using Employee_Signing_System.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public IQueryable<EmployeeTempBadge> getBadgeQueue()
        {
            /* List all requests with Assign Time -> 'null' in TempBadge Table */

            var q = _db.EmployeeTempBadges.Where(e=> e.AssignT == null);
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

        public IQueryable<EmployeeTempBadge> getOutList()
        {
            var q = _db.EmployeeTempBadges.Where(e => e.AssignT != null && e.SignOutT==null);
            return q;
        }

        public IQueryable<EmployeeTempBadge> getReport(DateTime sDate, DateTime eDate,
                                        string? fName, string? lName)
        {
            IQueryable<EmployeeTempBadge> q;
            if (fName == null && lName == null)
            {
                q = _db.EmployeeTempBadges.Where(e =>
                e.SignInT.Date >= sDate && e.SignInT.Date <= eDate).AsQueryable();
            }
            else
            {
                q = _db.EmployeeTempBadges.Where(e =>
                e.SignInT.Date >= sDate && e.SignInT.Date <= eDate
                && (e.EmployeeFirstName == fName || e.EmployeeLastName==lName))
                    .AsQueryable();
            }
            return q;
        }
        #endregion

        private void Save()
        {
            _db.SaveChanges();
        }
    }
}
