using StudentDetail.Repository;
using StudentDetail.ViewModel;
using StudentDetail.DataTransfers;
using StudentDetail.Models;
using StudentDetail.Response;
using Microsoft.EntityFrameworkCore;

namespace StudentDetail.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        protected readonly AngularAssignmentDbContext _angularAssignmentDbContext;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository, AngularAssignmentDbContext angularAssignmentDbContext)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _angularAssignmentDbContext = angularAssignmentDbContext;   
        }
        public async Task<List<StudentViewModel>> GetStudentlists()
        {
            var studentViewModel = new List<StudentViewModel>();

            try
            {
                studentViewModel = (await _studentRepository.GetStudentlists()).TransformToViewModelList();
                if(studentViewModel != null && studentViewModel.Count > 0)
                {
                    foreach (var student in studentViewModel)
                    {
                        var departmentViewModel = (await _departmentRepository.GetDepartmentByID(student.DepartmentID));
                       student.DepartmentName = departmentViewModel.DepartmentName;
                    }

                }
                return studentViewModel;
            }
            catch (Exception ex)
            {
                return studentViewModel;
            }
        }
        public async Task<StudentViewModel> GetStudentByID(int id)
        {
            var studentViewModel = new StudentViewModel();

            try
            {
                studentViewModel = (await _studentRepository.GetStudentByID(id)).TransformToViewModel();
                if (studentViewModel != null)
                {
                        var departmentViewModel = (await _departmentRepository.GetDepartmentByID(studentViewModel.DepartmentID));
                        studentViewModel.DepartmentName = departmentViewModel.DepartmentName;
                }

                return studentViewModel;
            }
            catch (Exception ex)
            {
                return studentViewModel;
            }
        }
        public async Task<StudentViewModel> InsertStudent(StudentViewModel studentViewModel)
        {
            var applicationResponse = new StudentViewModel();
            var studentDetails = new StudentDetails();

            try
            {
                if (studentViewModel != null)
                {
                    
                    var studentDetail = _studentRepository.GetStudentByID(studentViewModel.StudentID);

                    if (studentDetail.Result != null)
                    {
                        studentDetails.Course = studentViewModel.Course;
                        studentDetails.StudentName = studentViewModel.StudentName;
                        studentDetails.DepartmentId = studentViewModel.DepartmentID;
                        studentDetails.Specialization = studentViewModel.Specialization;
                        studentDetails.Percentage = studentViewModel.Percentage;
                        studentDetails.StudentId = studentViewModel.StudentID;
                         await _studentRepository.UpdateStudent(studentDetails);
                    }
                    else
                    {
                        studentDetails.Course = studentViewModel.Course;
                        studentDetails.StudentName = studentViewModel.StudentName;
                        studentDetails.DepartmentId = studentViewModel.DepartmentID;
                        studentDetails.Specialization = studentViewModel.Specialization;
                        studentDetails.Percentage = studentViewModel.Percentage;
                         _studentRepository.InsertStudent(studentDetails);
                    }

                    return applicationResponse;
                }

                return applicationResponse;
            }
            catch (Exception ex)
            {
                return applicationResponse;
            }
        }

        public async Task<StudentDetails> UpdateStudent(StudentDetails studentDetails)
        {
            var studentViewModel = new StudentDetails();

            try
            {

                studentViewModel = (await _studentRepository.UpdateStudent(studentDetails));

                return studentViewModel;
            }
            catch (Exception ex)
            {

                return studentViewModel;
            }
        }
        public async Task<bool> DeleteStudent(int id)
        {
            bool result = false;

            try
            {
                result = (await _studentRepository.DeleteStudent(id));

                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
