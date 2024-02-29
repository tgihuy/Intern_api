using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using EFCore2.Application.Services.Interface;

namespace EFCore2.Application.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ISubjectRepositories _repositories;

        public SubjectServices(ISubjectRepositories repositories)
        {
            _repositories = repositories;
        }
        public async Task<Subject> AddSubject(Subject subject)
        {
            return await _repositories.AddSubject(subject);
        }

        public async Task<Subject> DeleteSubject(int id)
        {
            return await _repositories.DeleteSubject(id);
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _repositories.GetSubjectById(id);
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _repositories.GetSubjects();
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            return await _repositories.UpdateSubject(id, subject);
        }
    }
}
