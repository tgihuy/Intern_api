using EFCore2.Application.Entities;

namespace EFCore2.Application.Services.Interface
{
    public interface IMarkServices
    {
        Task<IEnumerable<Mark>> GetAllMark();
        Task<Mark> GetMarkById(int studentId, int subjectId);
        Task<Mark> AddMark(Mark mark);
        Task<Mark> UpdateMark(int studentId, int subjectId, Mark mark);
        Task<Mark> DeleteMark(int studentId, int subjectId);
    }
}
