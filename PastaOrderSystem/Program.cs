using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Mapper;
using WebApi.Repository;
using WebApi.Service.Base;
using WebApi.Service.Beverage;
using WebApi.Service.ExtraIngredient;
using WebApi.Service.Junction;
using WebApi.Service.Order;
using WebApi.Service.Pasta;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:44360");
var Services = builder.Services;



// Add services to the container.

Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();

var Configuration = builder.Configuration;

Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

// for dependecy injection
Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
Services.AddScoped<IPastaService, PastaService>();
Services.AddScoped<IOrderService, OrderService>();
Services.AddScoped<IJunctionService, JunctionService>();
Services.AddScoped<IExtraIngredientService, ExtraIngredientService>();
Services.AddScoped<IBeverageService, BeverageService>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

Services.AddSingleton(mapperConfig.CreateMapper());

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
