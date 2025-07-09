using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Application.Services.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;
using Rescaptepet.Infraestrucutre.DbContext;
using Rescaptepet.Infraestrucutre.Repositories.Public;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 35)) // DB version
    )
);

// Add services to the container.
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
// Add build services
builder.Services.AddScoped<IAnimalService, AnimalService>();

//builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IDapper, MysqlContext>();
//builder.Services.AddScoped<MysqlContext>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();
