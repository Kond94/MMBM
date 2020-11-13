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
    [Route("/api/simcards")]
    public class SimcardsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ISimcardRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SimcardsController(IMapper mapper, ISimcardRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSimcard([FromBody] SaveSimcardResource simcardResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var simcard = mapper.Map<SaveSimcardResource, Simcard>(simcardResource);
            simcard.LastUpdate = DateTime.Now;

            repository.Add(simcard);
            await unitOfWork.CompleteAsync();

            simcard = await repository.GetSimcard(simcard.Id);

            var result = mapper.Map<Simcard, SimcardResource>(simcard);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSimcard(int id, [FromBody] SaveSimcardResource simcardResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var simcard = await repository.GetSimcard(id);

            if (simcard == null)
                return NotFound();

            mapper.Map<SaveSimcardResource, Simcard>(simcardResource, simcard);
            simcard.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            simcard = await repository.GetSimcard(simcard.Id);
            var result = mapper.Map<Simcard, SimcardResource>(simcard);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSimcard(int id)
        {
            var simcard = await repository.GetSimcard(id, includeRelated: false);

            if (simcard == null)
                return NotFound();

            repository.Remove(simcard);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSimcard(int id)
        {
            var simcard = await repository.GetSimcard(id);

            if (simcard == null)
                return NotFound();

            var simcardResource = mapper.Map<Simcard, SimcardResource>(simcard);

            return Ok(simcardResource);
        }

        [HttpGet]
        public async Task<ICollection<SimcardResource>> GetSimcards(string userId)
        {
            var queryResult = await repository.GetSimcards(userId);

            return mapper.Map<ICollection<Simcard>, ICollection<SimcardResource>>(queryResult);
        }
    }
}