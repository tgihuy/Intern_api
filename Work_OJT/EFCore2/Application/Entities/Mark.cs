namespace EFCore2.Application.Entities
{
    public class Mark
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int Scores { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
