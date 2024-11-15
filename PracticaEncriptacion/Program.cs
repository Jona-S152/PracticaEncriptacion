using BLL.Capitales;
using BLL.Paises;
using BLL.Practica;
using DAL.Capitales;
using DAL.Common;
using DAL.Context;
using DAL.Paises;
using DAL.Practica;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPaisesRepository, PaisesRepository>();
builder.Services.AddScoped<IPaisesService, PaisesService>();
builder.Services.AddScoped<ICapitalesRepository, CapitalesRepository>();
builder.Services.AddScoped<ICapitalesService, CapitalesService>();
builder.Services.AddScoped<IPracticaRepository, PracticaRepository>();
builder.Services.AddScoped<IPracticaService, PracticaService>();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EncriptacionDB")));

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDB")));

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
