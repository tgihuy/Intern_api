using EFCore.Application.Entities;

namespace EFCore.Application.Repositories
{
    public interface ICrudServices
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> AddAsync (Product product);
        Task UpdateAsync (Product product);
        Task DeleteAsync(int id);
    }
}
