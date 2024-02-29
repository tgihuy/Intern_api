using EFCore2.Application.Entities;

namespace EFCore2.Application.Repositories.Interface
{
    public interface IOtherAPIsRepositories
    {
        Task<Student> GetStudentWithMarksById(int id);
        Task<Student> GetStudentById(int id);
    }
}
