using StudentDetail.Models;
using StudentDetail.ViewModel;

namespace StudentDetail.DataTransfers
{
    public static class DepartmentDataTransfer
    {
        public static DepartmentViewModel TransformToViewModel(this Department department)
        {
            if (department != null)
            {
                return new DepartmentViewModel
                {
                    DepartmentID = department.DepartmentId,
                    DepartmentName = department.DepartmentName
                };
            }

            return null;
        }
        public static List<DepartmentViewModel> TransformToViewModelList(this List<Department> departments)
        {
            if (departments != null && departments.Any())
            {
                return departments.Select(x => x.TransformToViewModel()).ToList();
            }

            return new List<DepartmentViewModel>();
        }
    }
}
