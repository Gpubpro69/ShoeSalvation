using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Repository.Data;
using ShoeSalvation.Repository.Repositories;
using ShoeSalvation.Service.Interfaces;
using ShoeSalvation.Service.Mapping;
using ShoeSalvation.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();