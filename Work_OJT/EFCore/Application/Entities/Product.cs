using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Application.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Status { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
