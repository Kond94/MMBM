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
    public class SimcardRepository : ISimcardRepository
    {
        private readonly MMBMDbContext context;

        public SimcardRepository(MMBMDbContext context)
        {
            this.context = context;
        }

        public async Task<Simcard> GetSimcard(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Simcards.FindAsync(id);

            return await context.Simcards
              .Include(b => b.Employee)
              .SingleOrDefaultAsync(b => b.Id == id);
        }

        public void Add(Simcard simcard)
        {
            context.Simcards.Add(simcard);
        }

        public void Remove(Simcard simcard)
        {
            context.Remove(simcard);
        }

        public async Task<ICollection<Simcard>> GetSimcards(string userId)
        {
            var query = await context.Simcards
            .Where(b => b.Branch.UserId == userId)
              .Include(b => b.Employee).ToListAsync();

            return query;
        }

    }
}