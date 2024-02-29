
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Database2
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

        public async Task CreateDatabase()
        {
            using (var dbcontext = new WebContext())
            {
                string databasename = dbcontext.Database.GetDbConnection().Database;

                Console.WriteLine("Tạo " + databasename);

                bool result = await dbcontext.Database.EnsureCreatedAsync();
                string resultstring = result ? "tạo  thành  công" : "đã có trước đó";
                Console.WriteLine($"CSDL {databasename} : {resultstring}");
            }
        }
        public async Task DeleteDatabase()
        {
            using (var dbcontext = new WebContext())
            {
                string databasename = dbcontext.Database.GetDbConnection().Database;

                Console.WriteLine("Xoá " + databasename);

                bool deleted = await Database.EnsureDeletedAsync();
                    string deletionInfo = deleted ? "đã xóa" : "không xóa được";
                    Console.WriteLine($"{databasename} {deletionInfo}");         
            }
        }

        public async Task InsertDatabase()
        {
            var dbContext = new WebContext();
            for (int i = 1; i <= 5; i++)
            {
                var buyer = new Buyer { Name = $"Buyer {i}", PaymentMethod = "Credit Card" };
                dbContext.buyers.AddRangeAsync(buyer);
                await dbContext.SaveChangesAsync();

                for (int j = 1; j <= 2; j++)
                {
                    var order = new Order { CreateDate = DateTime.Now, Status = "Pending", BuyerId = buyer.Id, Address = $"Address {i}{j}" };
                    dbContext.orders.AddRangeAsync(order);
                    await dbContext.SaveChangesAsync();
                    for (int k = 1; k <= 2; k++)
                    {
                        var orderItem = new OrderItem { OrderId = order.Id, ProductId = k, Units = 1, UnitPrice = 10.00m };
                        dbContext.orderItems.AddRangeAsync(orderItem);
                        await dbContext.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task FindData(int id)
        {
            var dbcontext = new WebContext();
            var orders = await dbcontext.orders
                     .Where(o => o.BuyerId == id)
                     .ToListAsync(); 

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}, Create Date: {order.CreateDate}, Status: {order.Status}, Address: {order.Address}");
            }

        }


        public async Task MergeTable()
        {
            var qr =  from b in buyers
                     join o in orders on b.Id equals o.BuyerId
                     join oi in orderItems on o.Id equals oi.OrderId
                     select new
                     {
                         b.Id, b.Name, b.PaymentMethod, o.CreateDate, o.Status, o.Address, oi.ProductId, oi.Units, oi.UnitPrice
                     };

            var result = await qr.ToListAsync();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Id}, {item.Name}, {item.PaymentMethod}, " +
                    $"{item.CreateDate}, {item.Status}, {item.Address}, {item.ProductId}, {item.Units}, {item.UnitPrice}");
            }
        }

        public async Task UpdateBuyer(int id, string NewName)
        {
            var dbcontext = new WebContext();
            var buyer = (from b in dbcontext.buyers
                        where b.Id == id
                        select b).FirstOrDefault();
            if (buyer != null)
            {
                buyer.Name = NewName;
                dbcontext.SaveChangesAsync();
            }
        }

        public async Task DeleteBuyer()
        {
            var dbcontext = new WebContext();
            var debuyer = dbcontext.buyers.Take(1).FirstOrDefault();

            if (debuyer != null)
            {
                dbcontext.buyers.Remove(debuyer);
            }
            dbcontext.SaveChangesAsync();
        }
    }
}
