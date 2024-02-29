using System.Runtime.InteropServices;
using EFCore2.Application.Entities;
using EFCore2.Application.Repositories.Interface;
using EFCore2.Application.Services.Interface;

namespace EFCore2.Application.Services
{
    public class MarkServices : IMarkServices
    {
        private readonly IMarkRepositories _repositories;
        public MarkServices(IMarkRepositories repositories)
        {
            _repositories = repositories;
        }
        public async Task<Mark> AddMark(Mark mark)
        {
            return await _repositories.AddMark(mark);
        }

        public async Task<Mark> DeleteMark(int studentId, int subjectId)
        {
            return await _repositories.DeleteMark(studentId, subjectId);
        }

        public async Task<IEnumerable<Mark>> GetAllMark()
        {
            return await _repositories.GetAllMark();
        }

        public async Task<Mark> GetMarkById(int studentId, int subjectId)
        {
            return await _repositories.GetMarkById(studentId, subjectId);
        }

        public async Task<Mark> UpdateMark(int studentId, int subjectId, Mark mark)
        {
            return await _repositories.UpdateMark(studentId, subjectId, mark);
        }
    }
}
