using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using DataAccess.Repositories;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IHorarioRepository, HorarioRepository>();
builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();
builder.Services.AddScoped<ISalaRepository, SalaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(policy =>
    {
        policy.WithOrigins("https://localhost:7071")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithHeaders(HeaderNames.ContentType);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
