using EFCore2.Application.Data;
using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Application.Repositories
{
    public class StudentRepositories : IStudentRepositories
    {
        private readonly StudentDbContext _context;
        private readonly ILogger<StudentRepositories> _logger;

        public StudentRepositories(StudentDbContext context, ILogger<StudentRepositories> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Student> AddStudent(Student student)
        {
            try {
                if (student == null)
                {
                    return null;
                }
                _context.students.Add(student);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new Student()); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Student> DeleteStudent(int id)
        {
            try
            {
                Student studelete = await _context.students.FindAsync(id);
                if( studelete == null)
                {
                    return null;
                }
                _context.students.Remove(studelete);
                await _context.SaveChangesAsync();
                return await Task.FromResult(new Student());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                return await _context.students.FindAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await _context.students.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            try
            {              
                var stuUpdate = await _context.students.FindAsync(id);
                if (id == student.Id && stuUpdate != null)
                {
                    stuUpdate.Id = student.Id;
                    stuUpdate.Name = student.Name;
                    stuUpdate.Birthday = student.Birthday;
                    stuUpdate.Gender = student.Gender;
                    stuUpdate.Status = student.Status;

                    _context.Entry(stuUpdate).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return stuUpdate;
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
