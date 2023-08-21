using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Models;
using Project.Repository;
using Project.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// add repository
builder.Services.AddScoped<INguoiDungRepository, NguoiDungRepository>();

//add DBContext
builder.Services.AddDbContext<BanKhoaHocDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString(BaseModel.stringConnection));
});

var app = builder.Build();

app.UseCors(builder => {
    builder.AllowAnyHeader();
   builder.AllowAnyMethod();
   builder.AllowAnyOrigin(); 
});

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
