using System.Collections.Generic;
using System.Threading.Tasks;
using mmbm.Core.Models;

namespace mmbm.Core
{
    public interface ISimcardRepository
    {
        Task<Simcard> GetSimcard(int id, bool includeRelated = true);
        void Add(Simcard simcard);
        void Remove(Simcard simcard);
        Task<ICollection<Simcard>> GetSimcards(string userId);
    }
}