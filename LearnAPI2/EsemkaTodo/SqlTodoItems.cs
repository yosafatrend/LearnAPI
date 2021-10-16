using LearnAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public class SqlTodoItems : ITodoItems
    {
        private EsemkaTodoContext _esemkaTodoContext;
        public SqlTodoItems(EsemkaTodoContext esemkaTodoContext)
        {
            _esemkaTodoContext = esemkaTodoContext;
        }
        public TodoItem AddTodoItem(TodoItem item)
        {
            item.Id = Guid.NewGuid();
            _esemkaTodoContext.TodoItems.Add(item);
            _esemkaTodoContext.SaveChanges();
            return item;
        }

        public void DeleteTodoItem(Guid id)
        {
            var item = _esemkaTodoContext.TodoItems.Find(id);
            if (item != null)
            {
                _esemkaTodoContext.TodoItems.Remove(item);
                _esemkaTodoContext.SaveChanges();
            }
        }

        public TodoItem EditTodoItem(TodoItem item)
        {
            var existingItem = _esemkaTodoContext.TodoItems.Find(item.Id);
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.IsComplete = item.IsComplete;
            existingItem.DueAt = item.DueAt;

            _esemkaTodoContext.TodoItems.Update(existingItem);
            _esemkaTodoContext.SaveChanges();
            return existingItem;
        }

        public TodoItem GetTodoItem(Guid id)
        {
            return _esemkaTodoContext.TodoItems.Find(id);
        }

        public List<TodoItem> GetTodoItems()
        {
            return _esemkaTodoContext.TodoItems.ToList();
        }

    }
}
