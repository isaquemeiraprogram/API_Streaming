using API_Streaming.Context;
using API_Streaming.Mappers;
using API_Streaming.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conect_sql = builder.Configuration.GetConnectionString("Sqlconnect");
builder.Services.AddDbContext<DataBase>(options =>
options.UseMySql(conect_sql,ServerVersion.AutoDetect(conect_sql)));

builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<MusicaMapper>();
builder.Services.AddScoped<GeneroServise>();
builder.Services.AddScoped<GeneroMapper>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<ArtistaMapper>();


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
