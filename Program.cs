using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseInMemoryDatabase("DefaultConnection"));
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();