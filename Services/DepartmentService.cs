using Microsoft.EntityFrameworkCore;
using StudentDetail.DataTransfers;
using StudentDetail.Models;
using StudentDetail.Repository;
using StudentDetail.Response;
using StudentDetail.ViewModel;

namespace StudentDetail.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentViewModel>> GetDepartment()
        {
            var departmentViewModel = new List<DepartmentViewModel>();

            try
            {

                departmentViewModel = (await _departmentRepository.GetDepartments()).TransformToViewModelList();

                return departmentViewModel;
            }
            catch (Exception ex)
            {

                return departmentViewModel;
            }
        }
        public async Task<DepartmentViewModel> GetDepartmentByID(int id)
        {
            var departmentViewModel = new DepartmentViewModel();

            try
            {

                departmentViewModel = (await _departmentRepository.GetDepartmentByID(id)).TransformToViewModel();

                return departmentViewModel;
            }
            catch (Exception ex)
            {

                return departmentViewModel;
            }
        }
        public async Task<DepartmentViewModel> InsertDepartment(DepartmentViewModel departmentVM)
        {
            var departmentViewModel = new Department();

            try
            {
                var dept = new Department();
                if (departmentVM != null)
                {

                    var department = _departmentRepository.GetDepartmentByID(departmentVM.DepartmentID);

                    if (department.Result != null)
                    {
                        
                       dept.DepartmentId = departmentVM.DepartmentID;
                        dept.DepartmentName = departmentVM.DepartmentName;
                        await _departmentRepository.UpdateDepartment(dept);
                    }
                    else
                    {
                        dept.DepartmentName = departmentVM.DepartmentName;
                        await _departmentRepository.InsertDepartment(dept);
                    }

                    return departmentVM;
                }
                return departmentVM;
            }
            catch (Exception ex)
            {

                return departmentVM;
            }
        }
        public async Task<Department> UpdateDepartment(Department department)
        {
            var departmentViewModel = new Department();

            try
            {

                departmentViewModel = (await _departmentRepository.UpdateDepartment(department));

                return departmentViewModel;
            }
            catch (Exception ex)
            {

                return departmentViewModel;
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            bool result = false;

            try
            {
                result = (await _departmentRepository.DeleteDepartment(id));

                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
