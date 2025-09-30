using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RSWLogistics.LogisticsDb;
using RSWLogistics.ServiceInjections;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Set Kestrel URLs
builder.WebHost.UseUrls("http://0.0.0.0:5141");

// Add services
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<RSWDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RCWLogistics API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable Swagger in all environments (Production + Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RCWLogistics API V1");
    c.RoutePrefix = "swagger"; // Access at /swagger/index.html
});

// Middleware order
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
