using System.Threading.Tasks;
using mmbm.Core;

namespace mmbm.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMBMDbContext context;

        public UnitOfWork(MMBMDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}