using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mmbm.Controllers.Resources;
using mmbm.Core.Models;
using mmbm.Core;

namespace mmbm.Controllers
{
    [Route("/api/employees")]
    public class EmployeesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeesController(IMapper mapper, IEmployeeRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] SaveEmployeeResource employeeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = mapper.Map<SaveEmployeeResource, Employee>(employeeResource);
            employee.LastUpdate = DateTime.Now;

            repository.Add(employee);
            await unitOfWork.CompleteAsync();

            employee = await repository.GetEmployee(employee.Id);

            var result = mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] SaveEmployeeResource employeeResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await repository.GetEmployee(id);

            if (employee == null)
                return NotFound();

            mapper.Map<SaveEmployeeResource, Employee>(employeeResource, employee);
            employee.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            employee = await repository.GetEmployee(employee.Id);
            var result = mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await repository.GetEmployee(id, includeRelated: false);

            if (employee == null)
                return NotFound();

            repository.Remove(employee);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await repository.GetEmployee(id);

            if (employee == null)
                return NotFound();

            var employeeResource = mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(employeeResource);
        }

        [HttpGet]
        public async Task<ICollection<EmployeeResource>> GetEmployees(string userId)
        {
            var queryResult = await repository.GetEmployees(userId);

            return mapper.Map<ICollection<Employee>, ICollection<EmployeeResource>>(queryResult);
        }
    }
}