using StudentDetail.Models;
using StudentDetail.ViewModel;

namespace StudentDetail.DataTransfers
{
    public static class StudentDataTransfer
    {
        public static StudentViewModel TransformToViewModel(this StudentDetails studentDetails)
        {
            if (studentDetails != null)
            {
                return new StudentViewModel
                {
                    StudentID = studentDetails.StudentId,
                    StudentName = studentDetails.StudentName,
                    Course = studentDetails.Course,
                    Specialization = studentDetails.Specialization,
                    Percentage = studentDetails.Percentage,
                    DepartmentID = studentDetails.DepartmentId
                };
            }

            return null;
        }
        public static List<StudentViewModel> TransformToViewModelList(this List<StudentDetails> studentDetails)
        {
            if (studentDetails != null && studentDetails.Any())
            {
                return studentDetails.Select(x => x.TransformToViewModel()).ToList();
            }

            return new List<StudentViewModel>();
        }
    }
}
