using LearnAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public class SqlUsers : IUsers
    {
        private EsemkaTodoContext _esemkaTodoContext;
        public SqlUsers(EsemkaTodoContext esemkaTodoContext)
        {
            _esemkaTodoContext = esemkaTodoContext;
        }
        public User AddUser(User user)
        {
            _esemkaTodoContext.Add(user);
            _esemkaTodoContext.SaveChanges();
            return user;
        }

        public void DeleteUser(string email)
        {
            var user = _esemkaTodoContext.Users.Find(email);
            if (user != null)
            {
                _esemkaTodoContext.Users.Remove(user);
                _esemkaTodoContext.SaveChanges();
            }
        }

        public User EditUser(string email, User user)
        {
            var userExist = _esemkaTodoContext.Users.Find(email);
            if (userExist != null)
            {
                userExist.Email = user.Email;
                userExist.Name = user.Name;
                userExist.Gender = user.Gender;
                userExist.DateOfBirth = user.DateOfBirth;
                userExist.Role = user.Role;

                _esemkaTodoContext.Users.Update(userExist);
                _esemkaTodoContext.SaveChanges();
                
            }
            return userExist;
        }

        public User GetUserByEmail(string email)
        {
            return _esemkaTodoContext.Users.Find(email);
        }

        public List<User> GetUsers()
        {
            return _esemkaTodoContext.Users.ToList();
        }

        public List<TodoItem> GetUserTodoItems(string email)
        {
            return _esemkaTodoContext.TodoItems.Where(p => p.CreatedByEmail == email).ToList();
        }
    }
}
