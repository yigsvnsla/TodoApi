using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TodoApi.Interfaces.Todo;
namespace TodoApi.Models.Todo
{
    public class TodoModel : ITodo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
    }
}