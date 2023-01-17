using Employee_Signing_System.Models.Entity;
using Employee_Signing_System.Repositories;
using Employee_Signing_System.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ESS.Test.ATests
{
    // mock = TO insert Dummy Data
    public class UserTest
    {
        private readonly Mock<IUserDbRepository> _Userdb;

        public UserTest()
        {
            _Userdb = new Mock<IUserDbRepository>();
        }

        //-----------------------------------------------------
        //Moq data*
        public List<EmployeeTempBadge> newRec()
        {
            List<EmployeeTempBadge> newRec = new List<EmployeeTempBadge>
            {
                new EmployeeTempBadge()
                {
                    EmpId = 1,
                    EmployeeFirstName = "Sanidhya",
                    EmployeeLastName = null,
                    SignInT = DateTime.Now,
                    AssignT = null,
                    SignOutT = null
                },
                new EmployeeTempBadge()
                {
                    EmpId = 2,
                    EmployeeFirstName = "ABCD",
                    EmployeeLastName = "Red",
                    SignInT = DateTime.Today,
                    AssignT = null,
                    SignOutT = null
                },
                new EmployeeTempBadge()
                {
                    EmpId = 3,
                    EmployeeFirstName = null,
                    EmployeeLastName = "Red",
                    SignInT = DateTime.Today,
                    AssignT = null,
                    SignOutT = null
                }

            };
            return newRec;
        }

        [Fact]
        public void queue_req_Test1()
        {
            var data = newRec();
            _Userdb.Setup(e => e.AddTempRecord(data[1].EmpId)).Returns(true);

            var q1 = new UserService(_Userdb.Object);
            var result = q.queue_req(data[1].EmpId);

            Assert.IsType<int>(result);
            Assert.True(result==202);
        }
        [Fact]
        public void queue_req_Test2()
        {
            var data = newRec();
            _Userdb.Setup(e => e.AddTempRecord(data[2].EmpId)).Returns(true);

            var q2 = new UserService(_Userdb.Object);
            var result = q.queue_req(data[1].EmpId);

            Assert.IsType<int>(result);
            Assert.True(result == 202);
        }
    }
}
