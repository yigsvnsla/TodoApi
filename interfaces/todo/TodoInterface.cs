using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO.Todo;

namespace TodoApi.Interfaces.Todo
{
    #region Todo Interfaces
    public interface ITodo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsCompleted { get; set; }
    }
    #endregion

    #region Todo Service Interfaces
    public interface ITodoService
    {
        Task<ActionResult<List<TodoDto>>> GetAll();
        Task<ActionResult<TodoDto>> GetById(int id);
        Task<ActionResult<TodoDto>> Create(CreateTodoDto createTodoDto);
        Task<ActionResult<TodoDto>> Update(TodoDto todoDto);
        Task<ActionResult<TodoDto>> Delete(int id);
    }
    #endregion

    #region Todo Controller Interface
    public interface ITodoController
    {
        Task<ActionResult<List<TodoDto>>> GetAllController();
        Task<ActionResult<TodoDto>> GetByIdController(int id);
        Task<ActionResult<TodoDto>> CreateController(CreateTodoDto createTodoDto);
        Task<ActionResult<TodoDto>> UpdateController(TodoDto todoDto);
        Task<ActionResult<TodoDto>> DeleteController(int id);
    }
    #endregion 
}