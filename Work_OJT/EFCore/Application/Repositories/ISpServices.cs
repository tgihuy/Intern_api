using EFCore.Application.Entities;

namespace EFCore.Application.Repositories
{
    public interface ISpServices
    {
        Task<List<Product>> GetAllProductAsync(int id);
        Task DeleteProductByIdAsync(int id);

        Task InsertProduct(Product product);
    }
}
