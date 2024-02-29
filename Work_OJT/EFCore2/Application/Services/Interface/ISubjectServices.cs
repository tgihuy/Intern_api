using EFCore2.Application.Entities;

namespace EFCore2.Application.Services.Interface
{
    public interface ISubjectServices
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> AddSubject(Subject subject);
        Task<Subject> UpdateSubject(int id, Subject subject);
        Task<Subject> DeleteSubject(int id);
    }
}
