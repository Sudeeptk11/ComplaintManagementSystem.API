using ComplaintManagementSystem.API.Middleware;
using ComplaintManagementSystem.Application.Interfaces;
using ComplaintManagementSystem.Application.Services;
using ComplaintManagementSystem.Application.Validators;
using ComplaintManagementSystem.Infrastructure.Data;
using ComplaintManagementSystem.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddConnections().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateComplaintValidator>());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
