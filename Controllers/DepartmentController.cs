using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentDetail.Models;
using StudentDetail.Repository;
using StudentDetail.Services;
using StudentDetail.ViewModel;

namespace StudentDetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet("departmentlist")]
        public async Task<IActionResult> Department()
        {
            try
            {
                return Ok(await _departmentService.GetDepartment());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error occured in GetDepartment -> DepartmentController");
            }
        }
        [HttpGet]
        [Route("GetDepartmentByID/{Id}")]
        public async Task<IActionResult> GetDeptById(int Id)
        {
            return Ok(await _departmentService.GetDepartmentByID(Id));
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(DepartmentViewModel dep)
        {
            var result = await _departmentService.InsertDepartment(dep);

            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(Department dep)
        {
            await _departmentService.UpdateDepartment(dep);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteDepartment/{Id}")]
        public async Task<IActionResult> DeleteDepartment(int Id)
        {
           await _departmentService.DeleteDepartment(Id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
