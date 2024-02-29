using EFCore.Application.Entities;
using EFCore.Application.Repositories;
using EFCore.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectString = "Data Source=localhost:1521/ORCLCDB01; User Id=system; Password=Huy@133!";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ShopContext>(option =>
    option.UseOracle(connectString));
builder.Services.AddScoped<ICrudServices, CrudServices>();
builder.Services.AddScoped<ISpServices, SpServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
