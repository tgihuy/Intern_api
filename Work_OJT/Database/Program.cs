using System;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    class Program
    {

        static async Task Main(string[] args)
        {
            WebContext dbcontext = new WebContext();
            //await dbcontext.DeleteDatabase();
            //await dbcontext.CreateDatabase();
            //await dbcontext.InsertDatabase();
            //await dbcontext.MergeTable();
            //await dbcontext.FindData(1);
            //await dbcontext.DeleteData();
            //await dbcontext.UpdateData(5, "Tran Gia Huy");
            //await dbcontext.InsertBuyer(12, "Jane", "CashOnDelivery");
            //await dbcontext.UpdateBuyer(4, "Thinh", "Shipping");
            //await dbcontext.DeleteBuyer(11);
            await dbcontext.InsertDatabase2();
        }
    }
}
