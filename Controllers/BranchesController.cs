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
    [Route("/api/branches")]
    public class BranchesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBranchRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public BranchesController(IMapper mapper, IBranchRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] SaveBranchResource branchResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var branch = mapper.Map<SaveBranchResource, Branch>(branchResource);
            branch.LastUpdate = DateTime.Now;

            repository.Add(branch);
            await unitOfWork.CompleteAsync();

            branch = await repository.GetBranch(branch.Id);

            var result = mapper.Map<Branch, BranchResource>(branch);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, [FromBody] SaveBranchResource branchResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var branch = await repository.GetBranch(id);

            if (branch == null)
                return NotFound();

            mapper.Map<SaveBranchResource, Branch>(branchResource, branch);
            branch.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            branch = await repository.GetBranch(branch.Id);
            var result = mapper.Map<Branch, BranchResource>(branch);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await repository.GetBranch(id, includeRelated: false);

            if (branch == null)
                return NotFound();

            repository.Remove(branch);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            var branch = await repository.GetBranch(id);

            if (branch == null)
                return NotFound();

            var branchResource = mapper.Map<Branch, BranchResource>(branch);

            return Ok(branchResource);
        }

        [HttpGet]
        public async Task<ICollection<BranchResource>> GetBranches(string userId)
        {
            var queryResult = await repository.GetBranches(userId);

            return mapper.Map<ICollection<Branch>, ICollection<BranchResource>>(queryResult);
        }
    }
}