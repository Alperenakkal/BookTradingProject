using BookTradingProject.Data.Context;
using BookTradingProject.Repositories;
using BookTradingProject.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<VeriTabaniBaglami>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Singleton);

builder.Services.AddSingleton<IKullaniciReadRepository, KullaniciReadRepository>();
builder.Services.AddSingleton<IKullaniciWriteRepository, KullaniciWriteRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
