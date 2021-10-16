using LearnAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAPI2.EsemkaTodo
{
    public interface ITodoItems
    {
        List<TodoItem> GetTodoItems();
        TodoItem GetTodoItem(Guid id);
        TodoItem AddTodoItem(TodoItem item);
        void DeleteTodoItem(Guid id);
        TodoItem EditTodoItem(TodoItem item);
    }
}
