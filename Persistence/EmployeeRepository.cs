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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MMBMDbContext context;

        public EmployeeRepository(MMBMDbContext context)
        {
            this.context = context;
        }

        public async Task<Employee> GetEmployee(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await context.Employees.FindAsync(id);

            return await context.Employees
              .Include(b => b.Shop)
              .Include(b => b.Simcards)
              .SingleOrDefaultAsync(b => b.Id == id);
        }

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);
        }

        public void Remove(Employee employee)
        {
            context.Remove(employee);
        }

        public async Task<ICollection<Employee>> GetEmployees(string userId)
        {
            var query = await context.Employees
            .Where(b => b.Branch.UserId == userId)
              .Include(b => b.Shop)
              .Include(b => b.Simcards)
              .ToListAsync();

            return query;
        }

    }
}