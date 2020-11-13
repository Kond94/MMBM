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
    [Route("/api/shops")]
    public class ShopsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IShopRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ShopsController(IMapper mapper, IShopRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShop([FromBody] SaveShopResource shopResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var shop = mapper.Map<SaveShopResource, Shop>(shopResource);
            shop.LastUpdate = DateTime.Now;

            repository.Add(shop);
            await unitOfWork.CompleteAsync();

            shop = await repository.GetShop(shop.Id);

            var result = mapper.Map<Shop, ShopResource>(shop);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(int id, [FromBody] SaveShopResource shopResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var shop = await repository.GetShop(id);

            if (shop == null)
                return NotFound();

            mapper.Map<SaveShopResource, Shop>(shopResource, shop);
            shop.LastUpdate = DateTime.Now;

            await unitOfWork.CompleteAsync();

            shop = await repository.GetShop(shop.Id);
            var result = mapper.Map<Shop, ShopResource>(shop);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await repository.GetShop(id, includeRelated: false);

            if (shop == null)
                return NotFound();

            repository.Remove(shop);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShop(int id)
        {
            var shop = await repository.GetShop(id);

            if (shop == null)
                return NotFound();

            var shopResource = mapper.Map<Shop, ShopResource>(shop);

            return Ok(shopResource);
        }

        [HttpGet]
        public async Task<ICollection<ShopResource>> GetShops(string userId)
        {
            var queryResult = await repository.GetShops(userId);

            return mapper.Map<ICollection<Shop>, ICollection<ShopResource>>(queryResult);
        }
    }
}