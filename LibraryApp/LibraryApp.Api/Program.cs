using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Mapping;
using LibraryApp.Application.Services;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermettreClient", policy =>
    {
        policy.WithOrigins("https://localhost:7142")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILivreService, LivreService>();
builder.Services.AddScoped<ILivreRepository, LivreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("PermettreClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
