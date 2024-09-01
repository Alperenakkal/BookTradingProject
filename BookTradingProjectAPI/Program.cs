using BookTradingProjectAPI.Data.Context;
using BookTradingProjectAPI.Repositories;
using BookTradingProjectAPI.Repositories.IRepositories;
using BookTradingProjectAPI.Services.KullaniciService;
using BookTradingProjectAPI.Services.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with Scoped lifetime
builder.Services.AddDbContext<VeriTabaniBaglami>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

// Registering repositories and services
builder.Services.AddScoped<IKullaniciReadRepository, KullaniciReadRepository>();
builder.Services.AddScoped<IKullaniciWriteRepository, KullaniciWriteRepository>();
builder.Services.AddScoped<IKitapWriteRepository, KitapWriteRepository>();
builder.Services.AddScoped<IKitapReadRepository, KitapReadRepository>();
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<ITokenHandler, TokenHandler>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddHttpContextAccessor();



// Configure JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = jwtSettings.Audience,
            ValidIssuer = jwtSettings.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Add this to enable authentication
app.UseAuthorization();

app.MapControllers();

app.Run();
