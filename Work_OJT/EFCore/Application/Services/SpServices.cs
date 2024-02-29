using System.Data;
using EFCore.Application.Entities;
using EFCore.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace EFCore.Application.Services
{
    public class SpServices : ISpServices
    {
        private readonly ShopContext _context;

        public SpServices(ShopContext context)
        {
            _context = context;
        }
        public async Task DeleteProductByIdAsync(int id)
        {
            var query = $"begin\r\n    sp_deleteproduct({id});\r\nend;";
            await _context.Database.ExecuteSqlRawAsync(query);
        }

        public async Task<List<Product>> GetAllProductAsync(int id)
        {
            var idParam = new OracleParameter("p_categoryId", OracleDbType.Int32, ParameterDirection.Input)
            {
                Value = id
            };

            var cursorParam = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            var products = await _context.products
                .FromSqlRaw("BEGIN Sp_getallproduct(:p_categoryId, :p_cursor); END;",
                            idParam, cursorParam)
                .ToListAsync();

            return products;
        }

        public async Task InsertProduct(Product p)
        {
            var query = $"DECLARE\r\n  " +
                $"P_ID NUMBER;\r\n  " +
                $"P_NAME NVARCHAR2(200);\r\n  " +
                $"P_PRICE NUMBER;\r\n  " +
                $"P_STATUS NUMBER;\r\n  " +
                $"P_CATEGORYID NUMBER;\r\n  " +
                $"P_CREATEDATE DATE;\r\n" +
                $"BEGIN\r\n  " +
                $"P_ID := {p.Id};\r\n  " +
                $"P_NAME := '{p.Name}';\r\n  " +
                $"P_PRICE := {p.Price};\r\n  " +
                $"P_STATUS := {p.Status};\r\n  " +
                $"P_CATEGORYID := {p.CategoryId};\r\n  " +
                $"P_CREATEDATE := TO_DATE('{p.CreateDate.ToString("yyyy-MM-dd")}', 'YYYY-MM-DD');\r\n\r\n  " +
                $"INSERTPRODUCTS(\r\n    P_ID => P_ID,\r\n    P_NAME => P_NAME,\r\n    P_PRICE => P_PRICE,\r\n    P_STATUS => P_STATUS,\r\n    P_CATEGORYID => P_CATEGORYID,\r\n    P_CREATEDATE => P_CREATEDATE\r\n  );\r\n--rollback; \r\nEND;";
            await _context.Database.ExecuteSqlRawAsync(query);
            
        }
    }
}
