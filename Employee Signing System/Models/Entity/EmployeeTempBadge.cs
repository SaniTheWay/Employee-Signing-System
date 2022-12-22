using System;
using System.Collections.Generic;

namespace Employee_Signing_System.Models.Entity;

public partial class EmployeeTempBadge
{
    public int Id { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public string? TempBadge { get; set; }

    public DateTime SignInT { get; set; }

    public DateTime? SignOutT { get; set; }

    public DateTime? AssignT { get; set; }
}
