using EFCore2.Application.DTO;
using EFCore2.Application.Entities;
using EFCore2.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;
        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
            var subjects = await _subjectServices.GetSubjects();
            return Ok(subjects);
        }

        [HttpGet("id")]
        public async Task<SubjectDTO> GetSubjectById(int id)
        {
            var subjects = await _subjectServices.GetSubjectById(id);
            
            return new SubjectDTO (){Id = subjects.Id, Name = subjects.Name, Status = subjects.Status };
        }

        [HttpPost]
        public async Task<Subject> AddSubject(SubjectDTO subject)
        {
            var subjectInput = new Subject() { Id = subject.Id , Name = subject.Name, Status = subject.Status};
            return await _subjectServices.AddSubject(subjectInput);
        }

        [HttpPut("{id}")]
        public async Task<Subject> PutSubject(int id, SubjectDTO subject)
        {
            var subjectInput = new Subject() { Id = subject.Id, Name = subject.Name, Status = subject.Status };
            return await _subjectServices.UpdateSubject(id, subjectInput);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _subjectServices.DeleteSubject(id);
            return NoContent();
        }
    }
}
