using System;
using System.Collections.Generic;

namespace Employee_Signing_System.Models;

public partial class EmployeeStandardVert
{
    public string Id { get; set; } = null!;

    public string EFirstName { get; set; } = null!;

    public string? ELastName { get; set; }

    public string? PhotoUrl { get; set; }
}
