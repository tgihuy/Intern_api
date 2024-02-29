using EFCore2.Application.DTO;
using EFCore2.Application.Entities;
using EFCore2.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var student = await _studentServices.GetStudents();
            return Ok(student);
        }

        [HttpGet("id")]
        public async Task<StudentDTO> GetStudentById(int id)
        {
            var students = await _studentServices.GetStudentById(id);
            return new StudentDTO { Id = students.Id, Name = students.Name, Birthday = students.Birthday, Gender = students.Gender, Status = students.Status };
        }

        [HttpPost]
        public async Task<Student> AddStudent(StudentDTO student)
        {
            var studentInput = new Student() { Id = student.Id, Name = student.Name, Birthday = student.Birthday, Gender = student.Gender, Status = student.Status };
            return await _studentServices.AddStudent(studentInput);
        }

        [HttpPut("{id}")]
        public async Task<Student> PutStudent(int id, StudentDTO student)
        {
            var studentInput = new Student() { Id = student.Id, Name = student.Name, Birthday = student.Birthday, Gender = student.Gender, Status = student.Status };
            return await _studentServices.UpdateStudent(id, studentInput);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _studentServices.DeleteStudent(id);
            return NoContent();
        }
    }
}
