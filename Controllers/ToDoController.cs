using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NetCore2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore2.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class ToDoController : ControllerBase
    {
        // GET: /<controller>/
        private readonly TodoContext _context;

        public ToDoController(TodoContext context)
        {
            _context = context;

            if (_context.Items.Count() == 0)
            {
                _context.Items.Add(new Item { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        //[HttpGet]
        //public ActionResult<List<Item>> GetAll()
        //{
        //    return _context.Items.ToList();
        //}



       [HttpGet]
        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        //[HttpGet("{id}", Name = "GetTodo")]
        //public ActionResult<Item> GetById(long id)
        //{
        //    var item = _context.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}

        [HttpGet]
        public ActionResult GetById([FromQuery] int id)
        {
            return Ok(new Item { Id = 2, Name = "Sachin", IsComplete = true });
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public Item GetById(long id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
            {
                //return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(item);
            }
            
            //Save the values to DB
            return CreatedAtAction("Get",new { id = item.Id },item);
        }
    }
}
