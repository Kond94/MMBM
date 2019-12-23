using System;
using System.Threading.Tasks;

namespace mmbm.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}