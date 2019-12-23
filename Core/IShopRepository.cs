using System.Collections.Generic;
using System.Threading.Tasks;
using mmbm.Core.Models;

namespace mmbm.Core
{
    public interface IShopRepository
    {
        Task<Shop> GetShop(int id, bool includeRelated = true);
        void Add(Shop shop);
        void Remove(Shop shop);
        Task<ICollection<Shop>> GetShops(string userId);
    }
}