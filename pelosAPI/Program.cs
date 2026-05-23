using Microsoft.EntityFrameworkCore;
using pelosAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.AllowAnyOrigin()   // Permite peticiones desde cualquier origen (tus archivos HTML locales)
              .AllowAnyMethod()   // Permite GET, POST, PUT, DELETE, PATCH
              .AllowAnyHeader();  // Permite cualquier cabecera de datos
    });
});

// Controladores

builder.Services.AddControllers();

//Base de datos

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=peluqueria.db"));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configuración del pipeline de desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("PermitirFrontend");

app.MapControllers();

app.Run();