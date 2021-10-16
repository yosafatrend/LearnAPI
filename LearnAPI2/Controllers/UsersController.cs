using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LearnAPI2.EsemkaTodo;
using LearnAPI2.Filters;
using LearnAPI2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPI2.Controllers
{
    [Route("api/users/")]
    [ApiController]
    [TokenAuthenticationFilter]
    public class UsersController : ControllerBase
    {
        private IUsers _users;

        public UsersController(IUsers users, IHttpContextAccessor httpContextAccessor)
        {
            _users = users;
            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users.GetUsers());
        }

        [HttpGet]
        [Route("{email}")]
        public IActionResult GetUsersByEmail(string email)
        {
            return Ok(_users.GetUserByEmail(email));
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            return Ok(_users.AddUser(user));
        }

        [HttpPut]
        [Route("{email}")]
        public IActionResult EditUser(string email, User user)
        {
            return Ok(_users.EditUser(email, user));
        }

        [HttpDelete]
        [Route("{email}")]
        public IActionResult DeleteUser(string email)
        {
            _users.DeleteUser(email);
            return Ok();
        }

        [HttpGet]
        [Route("{email}/TodoItems")]
        public IActionResult GetUserTodoItem(string email) {
            return Ok(_users.GetUserTodoItems(email));
        }
    }
}
