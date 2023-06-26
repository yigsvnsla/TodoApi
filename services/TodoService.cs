using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {

        private readonly TodoDbContext todoDbContext;
        public TodoService(TodoDbContext dbContext)
        {
            todoDbContext = dbContext;
        }

        public async Task<TodoItemsModel> Create(TodoItemsModel todoItemsModel)
        {
            try
            {

                TodoItemsModel? j = await todoDbContext.TodoItems.FindAsync(todoItemsModel.Id);
                bool exists = await todoDbContext.TodoItems.AnyAsync(item => item.Equals(todoItemsModel));
                if (exists)
                {
                    throw new Exception("El valor ya existe en la base de datos.");
                }
                else
                {
                    todoDbContext.TodoItems.Add(todoItemsModel);
                    await todoDbContext.SaveChangesAsync();
                    return todoItemsModel;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
                throw;
            }
        }

        public async Task<List<TodoItemsModel>> FindTodos()
        {
            return await todoDbContext.TodoItems.ToListAsync();
        }
    }
}
