using EFCore2.Application.Entities;

namespace EFCore2.Application.DTO
{
    public class MarkDTO
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
