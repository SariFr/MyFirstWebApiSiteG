using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite.Controllers;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IuserRepository, userRepository>();
builder.Services.AddScoped<IuserService, userService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<WebElectricStoreContext>(option => option.UseSqlServer("Server=srv2\\pupils;Database=WebElectricStore;Trusted_Connection=True;TrustServerCertificate=True\" Microsoft.EntityFrameworkCore.SqlServer -force"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
