using Microsoft.AspNetCore.Mvc;
using ToDoApp.DbContext;
using ToDoApp.Entities;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllToDoItems()
        {
            var toDoItems = _context.ToDoItems.ToList();

            if(toDoItems == null)
            {
                return BadRequest("Something went wrong. Please try adding the ToDo item again");
            }

            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            if (id <=0)
            {
                return BadRequest("Something went wrong. Please try adding the ToDo item again");
            }

            var toDoItem = _context.ToDoItems.FirstOrDefault(x => x.Id == id);

            return Ok(toDoItem);
        }

        [HttpPost]
        public IActionResult AddToDoIdem(ToDoItem item)
        {
            if(item == null)
            {
               return BadRequest("Something went wrong. Please try adding the ToDo item again");
            }

            _context.Add(item);
            _context.SaveChanges();

            return Ok(item);
        }

        [HttpPut("/update")]
        public IActionResult UpdateToDoIdem(ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest("Something went wrong. Please try adding the ToDo item again");
            }

            var itemToUpdate = _context.ToDoItems.FirstOrDefault(x => x.Id == item.Id);

            if(itemToUpdate == null)
            {
                return NotFound("This particular ToDoItem has not been found");
            }

            itemToUpdate.Content = item.Content;
            itemToUpdate.Title = item.Title;
            itemToUpdate.Date = item.Date;
            itemToUpdate.IsCompleted = item.IsCompleted;
            itemToUpdate.IsDelete = false;

            _context.Add(item);
            _context.SaveChanges();

            return Ok(item);
        }

        [HttpPut("/remove")]
        public IActionResult RemoveToDoitem(ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest("Something went wrong. Please try adding the ToDo item again");
            }

            var itemToUpdate = _context.ToDoItems.FirstOrDefault(x => x.Id == item.Id);

            if (itemToUpdate == null)
            {
                return NotFound("This particular ToDoItem has not been found");
            }

            itemToUpdate.IsDelete = true;

            _context.Add(item);
            _context.SaveChanges();

            return Ok(item);
        }
    }
}
