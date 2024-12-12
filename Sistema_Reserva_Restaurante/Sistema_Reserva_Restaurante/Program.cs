using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sistema_Reserva_Restaurante.Exceptions;
using Sistema_Reserva_Restaurante.Models;
using Sistema_Reserva_Restaurante.Service.Usuario;
using Sistema_Reserva_Restaurante.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Definindo a classe ExceptionFilter como um filtro personalizado
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// Injeção de Dependência
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurando qual banco de dados será utilizado e pegando a string de conexão
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Validator
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioRegistroValidator>();

var app = builder.Build();

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
