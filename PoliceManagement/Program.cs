using PoliceManagement.DBContext;
using PoliceManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PMContext>(opts => opts.UseSqlServer("Data Source=.;Initial Catalog=PoliceDepartmentDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"));

builder.Services.AddScoped<IPMService, PMService>();// AddScoped is for creating one instance per HTTP request


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

app.Run();
