using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using EFCore2.Application.Services.Interface;

namespace EFCore2.Application.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepositories _repositories;

        public StudentServices(IStudentRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<Student> AddStudent(Student student)
        {
           return await _repositories.AddStudent(student);
        }

        public async Task<Student> DeleteStudent(int id)
        {
            return await _repositories.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repositories.GetStudentById(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _repositories.GetStudents();
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            return await _repositories.UpdateStudent(id, student);
        }
    }
}
