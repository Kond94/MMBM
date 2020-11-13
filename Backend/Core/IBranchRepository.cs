using System.Collections.Generic;
using System.Threading.Tasks;
using mmbm.Core.Models;

namespace mmbm.Core
{
    public interface IBranchRepository
    {
        Task<Branch> GetBranch(int id, bool includeRelated = true);
        void Add(Branch branch);
        void Remove(Branch branch);
        Task<ICollection<Branch>> GetBranches(string userId);
    }
}