using StudentDetail.Models;
using StudentDetail.Response;
using StudentDetail.ViewModel;

namespace StudentDetail.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetDepartment();

        Task<DepartmentViewModel> GetDepartmentByID(int id);
        Task<DepartmentViewModel> InsertDepartment(DepartmentViewModel dep);
        Task<Department> UpdateDepartment(Department dep);
        Task<bool> DeleteDepartment(int id);
    }
}
