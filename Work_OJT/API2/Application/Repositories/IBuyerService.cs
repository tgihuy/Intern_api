using API2.Application.Entities;

namespace API2.Application.Repositories
{
    public interface IBuyerService
    {
        Task<IEnumerable<Buyer>> GetAllBuyers();
        Task<Buyer> GetBuyerById(int id);
        Task<Buyer> AddBuyer(Buyer buyer);
        Task UpdateBuyer(Buyer buyer);
        Task DeleteBuyer(int id);

    }
}
