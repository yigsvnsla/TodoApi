using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoService
    {
        Task<List<TodoItemsModel>> FindTodos();
        // Task<List<TodoItem>> GetAll();
        // Task<TodoItem> GetById(int id);
        Task<TodoItemsModel> Create(TodoItemsModel todoItem);
        // Task<TodoItem> Update(TodoItem todoItem);
        // Task Delete(int id);
    }
}
