using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database2
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public string Status { get; set; }

        public int BuyerId { get; set; }

        public Buyer buyer { get; set; }

        public string Address { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{Id} - {CreateDate} - {Status} - {BuyerId} - {Address}");
        }
    }
}
