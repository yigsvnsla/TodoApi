using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;
namespace TodoApi.Controllers
{
    
    [ApiController]
    [Route("api/todos")]
    public class TodoController
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService){
            _todoService = todoService;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<TodoItemsModel>>> GetActionResultAsync()
        {
            return await _todoService.FindTodos();
        }
    }
}