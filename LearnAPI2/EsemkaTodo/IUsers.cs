using LearnAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public interface IUsers
    {
        List<User> GetUsers();
        User GetUserByEmail(string email);
        User AddUser(User user);
        User EditUser(string email, User user);
        void DeleteUser(string email);
        List<TodoItem> GetUserTodoItems(string email);
    }
}
