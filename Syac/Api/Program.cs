using Api.Controllers;
using Infraestructure.Config;
using Application.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register layers
builder.Services.AddInfraestructure(connectionString!);
builder.Services.AddApplication();

// CORS: Permitir todo (solo para desarrollo)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar CORS aquí
app.UseCors("AllowAll");

app.UseAuthorization();

// Minimal APIs
app.MapParametrosEndpoints();
app.MapPedidosEndpoints();

// Controllers
app.MapControllers();

app.Run();
