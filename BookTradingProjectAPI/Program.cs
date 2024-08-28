using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Repositories;
using BookTradingProjectAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VeriTabaniBaglami>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IKullaniciReadRepository, KullaniciReadRepository>();
builder.Services.AddSingleton<IKullaniciWriteRepository, KullaniciWriteRepository>();

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
