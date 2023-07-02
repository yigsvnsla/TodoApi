using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO.Todo;
using TodoApi.Interfaces.Todo;
using System.Net;

namespace TodoApi.Controllers.Todo
{
    [ApiController]
    [Route("todos")]
    public class TodoController : ITodoController
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotAcceptable)]
        public async Task<ActionResult<TodoDto>> CreateController([FromBody] CreateTodoDto createTodoDto)
        {
            return await _todoService.Create(createTodoDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetAllController()
        {
            return await _todoService.GetAll();
        }

        [HttpGet("id")]
        public async Task<ActionResult<TodoDto>> GetByIdController([FromRoute] int id)
        {
            return await _todoService.GetById(id);
        }

        [HttpPut]
        public async Task<ActionResult<TodoDto>> UpdateController([FromBody] TodoDto todoDto)
        {
            return await _todoService.Update(todoDto);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<TodoDto>> DeleteController(int id)
        {
            return await _todoService.Delete(id);
        }
    }
}