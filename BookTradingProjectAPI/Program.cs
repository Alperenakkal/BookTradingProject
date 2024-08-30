using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Repositories;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.BookService;
using BookTradingProjectAPI.Services.LoginService;
using BookTradingProjectAPI.Services.RegisterService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VeriTabaniBaglami>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

// Registering repositories and services
// Scoped services are preferred for repository patterns to ensure a new instance per request.
builder.Services.AddScoped<IKullaniciReadRepository, KullaniciReadRepository>();
builder.Services.AddScoped<IKullaniciWriteRepository, KullaniciWriteRepository>();
builder.Services.AddScoped<IKitapWriteRepository, KitapWriteRepository>(); // Correcting to use the actual implementation
builder.Services.AddScoped<IKitapReadRepository, KitapReadRepository>();   // Correcting to use the actual implementation
builder.Services.AddScoped<IKayitOlService, KayitolService>();
builder.Services.AddScoped<IGirisYapService, GirisYapService>();
builder.Services.AddScoped<IKitapService,KitapService>();

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
