using ApiGestaoProdutos.Application.AutoMapper;
using ApiGestaoProdutos.Application.Services;
using Microsoft.EntityFrameworkCore;
using ApiGestaoProdutos.Infrastructure.Data;
using ApiGestaoProdutos.Infrastructure.Repositories;
using ApiGestaoProdutos.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 38))));

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
