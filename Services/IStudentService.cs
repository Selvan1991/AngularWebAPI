using StudentDetail.Models;
using StudentDetail.ViewModel;

namespace StudentDetail.Services
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetStudentlists();
        Task<StudentViewModel> GetStudentByID(int id);
        Task<StudentViewModel> InsertStudent(StudentViewModel studentViewModel);
        Task<StudentDetails> UpdateStudent(StudentDetails objEmployee);
        Task<bool> DeleteStudent(int ID);
    }
}
