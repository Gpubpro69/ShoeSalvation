using Microsoft.EntityFrameworkCore;
using ShoeSalvation.Repository.Data;
using ShoeSalvation.Repository.Repositories;
using ShoeSalvation.Service.Interfaces;
using ShoeSalvation.Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// 1. Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// 2. Register Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
// 3. Auto migrate on startup — write this yourself
// Create a scope to resolve scoped services outside of a request


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    // Get the DbContext from the DI container
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply all pending migrations automatically
    db.Database.Migrate();
}
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


