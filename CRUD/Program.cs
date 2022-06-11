using CRUD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add services to banco.
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseMySql(
             "server=localhost;port=3306;database=MySQL80;uid=root;pwd=Biel@2905",
            new MySqlServerVersion(new Version(8, 0, 11))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();