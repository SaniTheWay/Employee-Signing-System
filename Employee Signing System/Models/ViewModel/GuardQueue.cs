using Employee_Signing_System.Models.Entity;

namespace Employee_Signing_System.Models.ViewModel
{
    public class GuardQueue
    {
        public IEnumerable<EmployeeTempBadge> TempEmployee { get; set; } = null!;
        //public int? status { get; set; }
    }
}
