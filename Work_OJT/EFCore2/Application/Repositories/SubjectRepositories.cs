using EFCore2.Application.Data;
using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Application.Repositories
{
    public class SubjectRepositories : ISubjectRepositories
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<SubjectRepositories> _logger;

        public SubjectRepositories(StudentDbContext context, ILogger<SubjectRepositories> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            try
            {
                if(subject == null)
                {
                    return null;
                }
                _context.subjects.Add(subject);
                await _context.SaveChangesAsync();
                return subject;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Subject> DeleteSubject(int id)
        {
            try
            {
                Subject subDelete = await _context.subjects.FindAsync(id);
                if(subDelete == null)
                {
                    return null;
                }
                _context.subjects.Remove(subDelete);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new Subject());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return await _context.subjects.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            try
            {
                return await _context.subjects.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            try
            {
                var subUpdate = await _context.subjects.FindAsync(id);
                if (subUpdate != null && id == subject.Id)
                {
                    subUpdate.Id = subject.Id;
                    subUpdate.Name = subject.Name;
                    subUpdate.Status = subject.Status;

                    _context.Entry(subUpdate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return subUpdate;
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
