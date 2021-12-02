using System.Collections.Generic;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryUseCases _categoryUseCases;

        public CategoryController(ICategoryUseCases categoryUseCases)
        {
            _categoryUseCases = categoryUseCases;
        }

        // GET api/values
        [HttpGet]
        public IList<Category> GetList()
        {
            return _categoryUseCases.GetList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return _categoryUseCases.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _categoryUseCases.Add(category);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Category Put(int id, [FromBody] Category category)
        {
            return _categoryUseCases.Update(id, category);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryUseCases.Delete(id);
        }
    }
}
