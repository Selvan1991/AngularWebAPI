using System;
using System.Collections.Generic;

namespace StudentDetail.Models;

public partial class StudentDetails
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string? Course { get; set; }

    public string? Specialization { get; set; }

    public decimal? Percentage { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
