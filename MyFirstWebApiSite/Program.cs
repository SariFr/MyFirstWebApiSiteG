using Microsoft.EntityFrameworkCore;
using Repositories;
using Repository;
using Service;
using Zxcvbn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IuserRepository, userRepository>();
builder.Services.AddTransient<IuserService, userService>();
builder.Services.AddTransient<IproductService, productService>();
builder.Services.AddTransient<IproductRepository, productRepository>();
builder.Services.AddTransient<IorderService, orderService>();
builder.Services.AddTransient<IorderRepository, orderRepository>();
builder.Services.AddTransient<IcategoryService, categoryService>();
builder.Services.AddTransient<IcategoryRepository, categoryRepository>();

builder.Services.AddControllers();

builder.Services.AddDbContext<WebElectricStoreContext>(option => option.UseSqlServer("Server=srv2\\pupils;Database=WebElectricStore;Trusted_Connection=True;TrustServerCertificate=True"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
