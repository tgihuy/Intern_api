using EFCore2.Application.Data;
using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Application.Repositories
{
    public class MarkRepositories : IMarkRepositories
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<MarkRepositories> _logger;

        public MarkRepositories(StudentDbContext context, ILogger<MarkRepositories> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Mark> AddMark(Mark mark)
        {
            try
            {
                if(mark == null)
                {
                    return null;
                }
                _context.marks.Add(mark);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new Mark());
            }catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Mark> DeleteMark(int studentId, int subjectId)
        {
            try
            {
                var markDelete = await _context.marks.FirstOrDefaultAsync(s => s.StudentId == studentId && s.SubjectId == subjectId);
                if(markDelete == null)
                {
                    return null;
                }
                _context.marks.Remove(markDelete);
                await _context.SaveChangesAsync();
                return await Task.FromResult<Mark>(markDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Mark>> GetAllMark()
        {
            try
            {
                return await _context.marks.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Mark> GetMarkById(int studentId, int subjectId)
        {
            var mark = await _context.marks.FirstOrDefaultAsync(m => m.StudentId == studentId && m.SubjectId == subjectId);
            try
            {
                if (mark == null)
                {
                    return null;
                }
                return mark;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Mark> UpdateMark(int studentId, int subjectId, Mark mark)
        {
            try
            {
                var markUpdate = await _context.marks.FirstOrDefaultAsync(m => m.StudentId == studentId && m.SubjectId == subjectId);
                if (markUpdate != null)
                {
                    markUpdate.StudentId = mark.StudentId;
                    markUpdate.SubjectId = mark.SubjectId;
                    markUpdate.Scores = mark.Scores;
                    markUpdate.CreateDate = mark.CreateDate;

                    _context.Entry(markUpdate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return markUpdate;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }
    }
}
