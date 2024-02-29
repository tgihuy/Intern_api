
using Microsoft.EntityFrameworkCore;

namespace Database1
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new WebContext();
            string dbname = dbcontext.Database.GetDbConnection().Database;
            Console.WriteLine(dbname);

        }
        
        static void Main(string[] args)
        {
            WebContext dbcontext = new WebContext();

        }
    }
}