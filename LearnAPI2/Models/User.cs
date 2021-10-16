using System;
using System.Collections.Generic;

#nullable disable

namespace LearnAPI2.Models
{
    public partial class User
    {
        public User()
        {
            TodoItems = new HashSet<TodoItem>();
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
