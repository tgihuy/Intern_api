using EFCore2.Application.Entities;

namespace EFCore2.Application.Repositories.Interface
{
    public interface IStudentRepositories
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> DeleteStudent(int id);
    }
}
