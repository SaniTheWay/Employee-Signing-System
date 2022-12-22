using System;
using System.Collections.Generic;

namespace Employee_Signing_System.Models.Entity;

public partial class EmployeeStandardVert
{
    public int Id { get; set; }

    public string EFirstName { get; set; } = null!;

    public string? ELastName { get; set; }

    public string? PhotoUrl { get; set; }
}
