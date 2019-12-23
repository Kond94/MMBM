using System.Collections.Generic;
using System.Threading.Tasks;
using mmbm.Core.Models;

namespace mmbm.Core
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int id, bool includeRelated = true);
        void Add(Employee employee);
        void Remove(Employee employee);
        Task<ICollection<Employee>> GetEmployees(string userId);
    }
}