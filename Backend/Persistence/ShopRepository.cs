using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mmbm.Core;
using mmbm.Core.Models;

namespace mmbm.Persistence
{
    public class ShopRepository : IShopRepository
    {
        private readonly MMBMDbContext context;

        public ShopRepository(MMBMDbContext context)
        {
            this.context = context;
        }

        public async Task<Shop> GetShop(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Shops.FindAsync(id);

            return await context.Shops
              .Include(b => b.Employee)
              .SingleOrDefaultAsync(b => b.Id == id);
        }

        public void Add(Shop shop)
        {
            context.Shops.Add(shop);
        }

        public void Remove(Shop shop)
        {
            context.Remove(shop);
        }

        public async Task<ICollection<Shop>> GetShops(string userId)
        {
            var query = await context.Shops
            .Where(b => b.Branch.UserId == userId)
              .Include(b => b.Employee).ToListAsync();

            return query;
        }

    }
}