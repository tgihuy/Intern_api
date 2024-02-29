using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Application.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; } 
        public bool Status { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
