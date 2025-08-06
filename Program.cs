using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
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
