using EFCore2.Application.Data;
using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Application.Repositories
{
    public class OtherAPIsRepositories : IOtherAPIsRepositories
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<OtherAPIsRepositories> _logger;
        public OtherAPIsRepositories(StudentDbContext context, ILogger<OtherAPIsRepositories> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<Student> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudentWithMarksById(int id)
        {
            var studentWithMarks = await _context.students
                .Include(s => s.Marks) // Include marks related to student
                .FirstOrDefaultAsync(s => s.Id == id);

            return studentWithMarks;
        }
    }
}
