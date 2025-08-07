using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SuperHero.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Enable Cross-Origin Resource Sharing
builder.Services.AddCors(options => options.AddPolicy(name: "SuperHero",
                         policy => 
                         {
                             policy.WithOrigins("http://localhost:4200").AllowAnyMethod()
                                   .AllowAnyHeader();        
                         }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("v1");
}

app.UseCors("SuperHero");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
