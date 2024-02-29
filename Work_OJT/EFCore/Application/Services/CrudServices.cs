using EFCore.Application.Entities;
using EFCore.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Application.Services
{
    
    public class CrudServices : ICrudServices
    {
        private readonly ShopContext _context;
        private readonly ILogger<CrudServices> _logger;
        public CrudServices(ShopContext context, ILogger<CrudServices> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                if (product == null)
                {
                    return null;
                }

                _context.products.Add(product);
                await _context.SaveChangesAsync();
                return await Task.FromResult(product);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if(product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _context.products.ToListAsync();
            }
            catch(Exception e) 
            {
                _logger.LogError(e.ToString());
                return null;
            }
            
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
