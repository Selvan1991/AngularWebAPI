using StudentDetail.Models;
using StudentDetail.ViewModel;

namespace StudentDetail.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentByID(int id);
        Task<Department> InsertDepartment(Department dep);
        Task<Department> UpdateDepartment(Department dep);
        Task<bool> DeleteDepartment(int id);
    }
}
