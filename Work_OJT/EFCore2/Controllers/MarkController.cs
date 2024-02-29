using EFCore2.Application.DTO;
using EFCore2.Application.Entities;
using EFCore2.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkServices _markServices;
        public MarkController(IMarkServices markServices)
        {
            _markServices = markServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetMarks()
        {
            var products = await _markServices.GetAllMark();
            return Ok(products);
        }
        [HttpGet("{studentId}/{subjectId}")]
        public async Task<MarkDTO> GetMarkById(int studentId, int subjectId)
        {
            var mark = await _markServices.GetMarkById(studentId, subjectId);
            return new MarkDTO() { StudentId = mark.StudentId, SubjectId = mark.SubjectId, Scores = mark.Scores, CreateDate = mark.CreateDate};
        }

        [HttpPost]
        public async Task<Mark> AddMark(MarkDTO mark)
        {
            var addedMark = new Mark() {StudentId = mark.StudentId, SubjectId = mark.SubjectId, Scores = mark.Scores, CreateDate = mark.CreateDate };
            return await _markServices.AddMark(addedMark);
        }

        [HttpPut("{studentId}/{subjectId}")]
        public async Task<Mark> UpdateMark(int studentId, int subjectId, MarkDTO mark)
        {
            var updatedMark = new Mark() { StudentId = mark.StudentId, SubjectId = mark.SubjectId, Scores = mark.Scores, CreateDate = mark.CreateDate };
            return await _markServices.UpdateMark(studentId,subjectId, updatedMark);
        }

        [HttpDelete("{studentId}/{subjectId}")]
        public async Task<IActionResult> DeleteMark(int studentId, int subjectId)
        {
            var deletedMark = await _markServices.DeleteMark(studentId, subjectId);
            if (deletedMark == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
