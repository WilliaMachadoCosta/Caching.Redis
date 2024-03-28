using AutoMapper;
using Caching.Domain;
using Caching.Infra;
using Caching.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
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

builder.Services.AddSingleton(p =>
{
    var configure = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Cache"));
    return ConnectionMultiplexer.Connect(configure);
});

builder.Services.AddSingleton<IDatabase>(provider => {
    var redis = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Cache"));
    return redis.GetDatabase();
});


builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddSingleton<IRedisRepository<TaskItem>, RedisRepository<TaskItem>>();


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
