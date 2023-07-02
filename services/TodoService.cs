using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO.Todo;
using TodoApi.Interfaces.Todo;
using TodoApi.Models.Todo;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _ctx;
        private readonly IMapper _mapper;


        public TodoService(TodoDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<ActionResult<TodoDto>> Create(CreateTodoDto createTodoDto)
        {
            TodoModel? FindTodo = await _ctx.TodoItems.FirstOrDefaultAsync(item => item.Title == createTodoDto.Title);
            if (FindTodo != null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "This everything already exists",
                    Detail = "This Todo is already previously saved in our data source",
                    Status = StatusCodes.Status406NotAcceptable,
                    Type = "https://example.com/errors/not-found"
                };
                return new ObjectResult(problemDetails) { StatusCode = StatusCodes.Status406NotAcceptable }; ;
            }
            TodoModel CreateTodoModel = _mapper.Map<CreateTodoDto, TodoModel>(createTodoDto);
            _ctx.TodoItems.Add(CreateTodoModel);
            await _ctx.SaveChangesAsync();
            return new ObjectResult(CreateTodoModel) { StatusCode = StatusCodes.Status201Created };
        }

        public async Task<ActionResult<TodoDto>> Delete(int id)
        {
            TodoModel? FindTodo = await _ctx.TodoItems.FirstOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<TodoDto>(FindTodo);
        }

        public async Task<ActionResult<List<TodoDto>>> GetAll()
        {
            List<TodoModel> todoModels = await _ctx.TodoItems.ToListAsync();
            List<TodoDto> todoDtos = _mapper.Map<List<TodoDto>>(todoModels);
            return todoDtos;
        }

        public async Task<ActionResult<TodoDto>> GetById(int id)
        {
            TodoModel? FindTodo = await _ctx.TodoItems.FirstOrDefaultAsync(item => item.Id == id);
            return new ObjectResult(FindTodo);
        }

        public async Task<ActionResult<TodoDto>> Update(TodoDto todoDto)
        {
            TodoModel? FindTodo = await _ctx.TodoItems.FirstOrDefaultAsync(item => item.Id == todoDto.Id);
            return new ObjectResult(FindTodo);
        }


    }
}
// ;
