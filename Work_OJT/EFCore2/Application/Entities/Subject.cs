namespace EFCore2.Application.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Mark>? Marks { get; set; }
    }
}
