using Microsoft.EntityFrameworkCore;
using StudentDetail.Models;

namespace StudentDetail.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        protected readonly AngularAssignmentDbContext _angularAssignmentDbContext;
        public DepartmentRepository(AngularAssignmentDbContext dbcontext)
        {
            _angularAssignmentDbContext = dbcontext;
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await _angularAssignmentDbContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartmentByID(int id)
        {
            return await _angularAssignmentDbContext.Departments.FindAsync(id);
        }
        public async Task<Department> InsertDepartment(Department department)
        {

            if(department != null)
            {
                _angularAssignmentDbContext.Departments.Add(department);
                await _angularAssignmentDbContext.SaveChangesAsync();
                
            }
            return department;
        }
        public async Task<Department> UpdateDepartment(Department objDepartment)
        {
            _angularAssignmentDbContext.Entry(objDepartment).State = EntityState.Modified;
            await _angularAssignmentDbContext.SaveChangesAsync();
            return objDepartment;
        }
        public async Task<bool> DeleteDepartment(int id)
        {
            bool result = false;
            var department = _angularAssignmentDbContext.Departments.Find(id);
            if (department != null)
            {
                _angularAssignmentDbContext.Entry(department).State = EntityState.Deleted;
               await _angularAssignmentDbContext.SaveChangesAsync();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
