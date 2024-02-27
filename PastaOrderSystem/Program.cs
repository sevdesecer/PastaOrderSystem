using AutoMapper;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using PastaOrderSystem.Context;
using PastaOrderSystem.Mapper;
using PastaOrderSystem.Repository;
using PastaOrderSystem.Service.Base;
using PastaOrderSystem.Service.Beverage;
using PastaOrderSystem.Service.ExtraIngredient;
using PastaOrderSystem.Service.Junction;
using PastaOrderSystem.Service.Order;
using PastaOrderSystem.Service.Pasta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

// for dependecy injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
builder.Services.AddScoped<IPastaService, PastaService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IJunctionService, JunctionService>();
builder.Services.AddScoped<IExtraIngredientService, ExtraIngredientService>();
builder.Services.AddScoped<IBeverageService, BeverageService>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

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
