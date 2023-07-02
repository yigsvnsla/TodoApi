using AutoMapper;
using TodoApi.DTO.Todo;
using TodoApi.Models.Todo;

namespace TodoApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoModel, TodoDto>();
            CreateMap<TodoDto, TodoModel>();
            CreateMap<TodoModel, CreateTodoDto>();
            CreateMap<CreateTodoDto, TodoModel>();
        }
    }

}