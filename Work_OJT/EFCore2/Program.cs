using System.Configuration;
using EFCore2.Application.Data;
using EFCore2.Application.Repositories;
using EFCore2.Application.Repositories.Interface;
using EFCore2.Application.Services;
using EFCore2.Application.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddOracle<StudentDbContext>(builder.Configuration.GetConnectionString("OracleConn"));
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConn")));
builder.Services.AddScoped<IMarkRepositories, MarkRepositories>();
builder.Services.AddScoped<IMarkServices, MarkServices>();
builder.Services.AddScoped<IStudentRepositories, StudentRepositories>();
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ISubjectRepositories, SubjectRepositories>();
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
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
