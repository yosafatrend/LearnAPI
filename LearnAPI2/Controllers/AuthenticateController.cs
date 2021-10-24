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
    [Route("api/auth/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        private readonly IUsers users;
        //private IHttpContextAccessor httpContextAccessor;
        public AuthenticateController(ITokenManager tokenManager, IUsers users)
        {
            this.tokenManager = tokenManager;
            this.users = users;
            //this.httpContextAccessor = httpContextAccessor;
            //var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        }
        [HttpPost]
        public IActionResult Authenticate(Auth user)
        {
            if (tokenManager.Authenticate(user))
            {
                return Ok(tokenManager.NewToken(user.email));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("me")]
        [TokenAuthenticationFilter]
        public IActionResult GetAuth()
        {
            var email = User.Identity.Name;
            return Ok(users.GetUserByEmail(email)) ;
        }

      
    }
}
