using StudentDetail.Models;
using StudentDetail.Response;
using StudentDetail.ViewModel;

namespace StudentDetail.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentDetails>> GetStudentlists();
        Task<StudentDetails> GetStudentByID(int id);
        //Task<StudentDetails> InsertStudent(StudentDetails objEmployee);
        //Task<StudentViewModel> InsertStudent(StudentViewModel studentViewModel);
        void InsertStudent(StudentDetails studentDetails);
        Task<StudentDetails> UpdateStudent(StudentDetails objEmployee);
        Task<bool> DeleteStudent(int ID);
    }
}
