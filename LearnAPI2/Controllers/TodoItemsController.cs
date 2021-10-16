using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAPI2.EsemkaTodo;
using LearnAPI2.Filters;
using LearnAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI2.Controllers
{
    [Route("api/todoitems/")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class TodoItemsController : ControllerBase
    {
        private ITodoItems _todoItems;

        public TodoItemsController(ITodoItems todoItems)
        {
            _todoItems = todoItems;
        }

        [HttpGet]
        public IActionResult GetTodoItems()
        {
            return Ok(_todoItems.GetTodoItems());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTodoItem(Guid id)
        {
            var item = _todoItems.GetTodoItem(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound($"Todo items with id : {id} was not found");
        }

        [HttpPost]
        public IActionResult AddTodoItem(TodoItem item)
        {
            _todoItems.AddTodoItem(item);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + item.Id, item);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditTodoItem(Guid id, TodoItem item)
        {
            item.Id = id;
            _todoItems.EditTodoItem(item);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTodoItem(Guid id)
        {
            _todoItems.DeleteTodoItem(id);
            return NoContent();
        }
    }
}
