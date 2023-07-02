using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models.Todo
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            TodoItems= Set<TodoModel>();
        }

        public DbSet<TodoModel> TodoItems { get; set; }
    }
}
