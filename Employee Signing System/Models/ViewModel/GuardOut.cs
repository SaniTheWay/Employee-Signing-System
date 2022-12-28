using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Models.ViewModel
{
    public class GuardOut
    {
        public EmployeeTempBadge TempEmpRecord { get; set; } = null!;
        public string TempImage { get; set; }
    }
}
