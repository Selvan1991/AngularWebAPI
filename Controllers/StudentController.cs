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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentService _studentService;

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository department,
            IStudentService studentService)
        {
            _studentRepository = studentRepository;
            _departmentRepository = department;
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudents")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _studentService.GetStudentlists());
        }
        [HttpGet]
        [Route("GetStudentByID/{Id}")]
        public async Task<IActionResult> GetDeptById(int Id)
        {
            return Ok(await _studentService.GetStudentByID(Id));
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> Post([FromBody] StudentViewModel studentDetail) 
        {
            try
            {
                return Ok(await _studentService.InsertStudent(studentDetail));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error occured in Book -> AppointmentController");
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> Put(StudentDetails studentDetails)
        {
            await _studentRepository.UpdateStudent(studentDetails);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("DeleteStudent/{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var result = await _studentRepository.DeleteStudent(Id);
            return new JsonResult("Deleted Successfully");
        }

    }
}
