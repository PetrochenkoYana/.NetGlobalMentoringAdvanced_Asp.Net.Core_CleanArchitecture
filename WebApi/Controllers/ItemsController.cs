using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemUseCases _itemUseCases;

        public ItemsController(IItemUseCases itemUseCases)
        {
            _itemUseCases = itemUseCases;
        }

        // GET api/values
        [HttpGet]
        public IList<Item> GetList([FromBody]ItemsRequest request)
        {
            return _itemUseCases.GetList(request);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            return _itemUseCases.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Item Post([FromBody] Item item)
        {
            return _itemUseCases.Add(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Item Put(int id, [FromBody] Item item)
        {
            return _itemUseCases.Update(id, item);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemUseCases.Delete(id);
        }
    }
}
