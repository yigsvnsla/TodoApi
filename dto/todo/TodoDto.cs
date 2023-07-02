using TodoApi.Interfaces.Todo;

namespace TodoApi.DTO.Todo
{
    public class TodoDto : ITodo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsCompleted { get; set; }
    }

}