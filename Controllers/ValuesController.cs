using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore2.Models;
using NetCore2.Repositories;

namespace NetCore2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IItemService _service;
        public ValuesController(IItemService service)
        {
            _service=service;

        }
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            try
            {
              return _service.FetchItems();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
