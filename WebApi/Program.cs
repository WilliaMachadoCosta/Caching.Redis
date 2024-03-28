using AutoMapper;
using Caching.Domain;
using Caching.Infra;
using Caching.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("todo"));
});

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Cache"));

builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddTransient<IRepository, Repository>();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<TaskItemViewModel, TaskItem>();
    cfg.CreateMap<TaskItem, TaskItemViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
