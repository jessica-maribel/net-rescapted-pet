using Microsoft.EntityFrameworkCore;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Application.Services.Public;
using Rescaptepet.Domain.Interfaces.Public;
using Rescaptepet.Infraestructure.Connections;
using Rescaptepet.Infraestructure.Repositories.Public;
using Rescaptepet.Infraestrucutre.DbContext;
using Rescaptepet.Infraestrucutre.Repositories.Public;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 35)) // DB version
    )
);

// Add services to the container.
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAdopcionRepository, AdopcionRepository>();
builder.Services.AddScoped<IFederacionRepository, FederacionRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IReporteRescateRepository, ReporteRescateRepository>();

// Add build services
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAdopcionService, AdopcionService>();
builder.Services.AddScoped<IFederacionService, FederacionService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IReporteRescateService, ReporteRescateService>();

//builder.Services.AddScoped<MysqlContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();

