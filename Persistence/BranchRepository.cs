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
    public class BranchRepository : IBranchRepository
    {
        private readonly MMBMDbContext context;

        public BranchRepository(MMBMDbContext context)
        {
            this.context = context;
        }

        public async Task<Branch> GetBranch(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Branches.FindAsync(id);

            return await context.Branches
              .Include(b => b.Employees)
              .Include(b => b.Simcards)
              .Include(b => b.Shops)
              .SingleOrDefaultAsync(b => b.Id == id);
        }

        public void Add(Branch branch)
        {
            context.Branches.Add(branch);
        }

        public void Remove(Branch branch)
        {
            context.Remove(branch);
        }

        public async Task<ICollection<Branch>> GetBranches(string userId)
        {
            var query = await context.Branches
            .Where(b => b.UserId == userId)
            .Include(b => b.Employees)
            .ThenInclude(e => e.Simcards)
            .Include(b => b.Simcards)
            .ThenInclude(s => s.Employee)
            .Include(b => b.Shops)
            .ThenInclude(s => s.Employee)
            .ToListAsync();

            return query;
        }

    }
}