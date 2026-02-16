
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SegurosNET8_Clean.IoC;
using SegurosNET8_Clean.RepositoryEFCore.DataContext;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Deshabilitar HTTPS
    EnvironmentName = Environments.Development,
    WebRootPath = "wwwroot"
});
builder.WebHost.UseUrls("http://localhost:5261", "http://0.0.0.0:5261");

// Obtener configuración (esto se hace automáticamente)
var configuration = builder.Configuration;

var connectionString = configuration.GetConnectionString("connSQLServer");
Console.WriteLine($"Cadena de conexión: {connectionString ?? "NO CONFIGURADA"}");
builder.Services.AddDbContext<AseguradoraContext>(options =>
    options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSegurosDependencies(configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy => policy
            .WithOrigins("http://localhost:4200", "http://localhost:32768", "http://localhost:5153", "http://localhost:5144")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDev");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
