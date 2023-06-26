using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItemsModel> TodoItems { get; set; }
    }
}
