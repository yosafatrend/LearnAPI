using LearnAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public interface ITokenManager
    {
        bool Authenticate(Auth user);
        string NewToken();
        ClaimsPrincipal VerifyToken(string token);
    }
}
