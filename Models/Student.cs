using System;
using System.Collections.Generic;

namespace StudentDetail.Models;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string? Course { get; set; }

    public int? CourseDuration { get; set; }

    public string? TrainingMode { get; set; }

    public string? LocationInfo { get; set; }
}
