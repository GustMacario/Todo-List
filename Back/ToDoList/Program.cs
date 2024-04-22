using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Interfaces.Repositories;
using ToDoList.Interfaces.Services;
using ToDoList.Repositories;
using ToDoList.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins("http://localhost:4200"));
});

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared"));

builder.Services.AddTransient<IToDoService, TodoService>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
