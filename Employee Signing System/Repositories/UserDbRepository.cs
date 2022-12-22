﻿using Employee_Signing_System.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Employee_Signing_System.Repositories
{
    public class UserDbRepository:IUserDbRepository
    {
        EmployeeSigningSystemContext _db;
        public UserDbRepository()
        {
            _db = new EmployeeSigningSystemContext();
        }
        public UserDbRepository(EmployeeSigningSystemContext dbContext)
        {
            _db = dbContext;
        }
    
        #region GetList

        /* To Search the employee name in 'EmployeeVert' Table */
        public List<EmployeeStandardVert> GetList(string fname, string? lname)
        {
            var empList = _db.EmployeeStandardVerts.Where(q => 
                            q.EFirstName == fname || q.ELastName==lname)
                                .ToList();
            return empList;
        }
        #endregion

        #region AddTempRecord
        /* Add Temporary Record to the 'EmpTempBadge' Table */
        public bool AddTempRecord(int id)
        {

            var emp = _db.EmployeeStandardVerts.Find(id);
            //if (emp == null) throw new Exception("Internal Server Error!");
            if(emp == null) return false;
            EmployeeTempBadge newRec = new EmployeeTempBadge
            {
                EmployeeFirstName = emp.EFirstName,
                EmployeeLastName = emp?.ELastName,
                SignInT = DateTime.Now,
                AssignT = null,
                SignOutT = null
            };
            
            _db.EmployeeTempBadges.Add(newRec);
            Save();
            return true;
        }
        #endregion

        #region Assign SignOut 
        public bool AssignSignOut(string badge)
        {
            var q = _db.EmployeeTempBadges.Where(e => e.SignOutT==null && e.TempBadge == badge ).ToArray();
            if (q.IsNullOrEmpty())
            {
                Console.WriteLine("Badge not found!");
                return false;
            }
            q[0].SignOutT = DateTime.Now;
            Save();
            return true;
        }
        #endregion

        private void Save()
        {
            _db.SaveChanges();
        }
    }
}
