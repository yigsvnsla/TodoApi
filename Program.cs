using Microsoft.EntityFrameworkCore;
using TodoApi.Interfaces.Todo;
using TodoApi.Models.Todo;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to container
builder.Services.AddControllers();
builder.Services.AddDbContext<TodoDbContext>(opt => opt.UseInMemoryDatabase("DefaultConnection"));

// inject dependencies
builder.Services.AddScoped<ITodoService, TodoService>();

// configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// add swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
// app workers running
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseExceptionHandler("/error"); // Cambia "/error" por la ruta que desees utilizar para manejar las excepciones en producción
app.UseHsts();
app.UsePathBase(new PathString("/api/"));
app.UseRouting();
app.Run();