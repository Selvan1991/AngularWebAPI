using System;
using System.Collections.Generic;

namespace StudentDetail.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<StudentDetails> StudentDetails { get; set; } = new List<StudentDetails>();
}
