using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Models.ViewModel
{
    public class GuardQueue
    {
        public EmployeeTempBadge TempEmployee { get; set; } = null!;
        public string TempEmpImg { get; set; }
        //public int? status { get; set; }
    }
}
