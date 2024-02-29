
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Database1
{
    public class WebContext : DbContext
    {
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Buyer> buyers { get; set; }

        private const string connectString = @"
            Data Source=localhost:1521/ORCLCDB01;
            User Id=system;
            Password=Huy@133!";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Tạo ILoggerFactory 
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseOracle(connectString)           
                          .UseLoggerFactory(loggerFactory);                     

        }

        
        
    }
}
