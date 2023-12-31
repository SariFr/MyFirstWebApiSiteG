using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstWebApiSite.middleware;
using NLog.Web;
using PresidentsApp.Middlewares;
using Repositories;
using Repository;
using Service;
using Zxcvbn;


var builder = WebApplication.CreateBuilder(args);

// Add se1rvices to the container.

builder.Services.AddTransient<IuserRepository, userRepository>();
builder.Services.AddTransient<IuserService, userService>();
builder.Services.AddTransient<IproductService, productService>();
builder.Services.AddTransient<IproductRepository, productRepository>();
builder.Services.AddTransient<IorderService, orderService>();
builder.Services.AddTransient<IorderRepository, orderRepository>();
builder.Services.AddTransient<IcategoryService, categoryService>();
builder.Services.AddTransient<IcategoryRepository, categoryRepository>();
builder.Services.AddTransient<IratingRepository, ratingRepository>();
builder.Services.AddTransient<IratingService, ratingService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();

builder.Services.AddDbContext<WebElectricStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("WebElectricStore")));
builder.Host.UseNLog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}
app.UseRatingMiddleware();

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
