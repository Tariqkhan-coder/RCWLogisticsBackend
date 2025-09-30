using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RSWLogistics.LogisticsDb;
using RSWLogistics.ServiceInjections;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Important: yahan rakho
builder.WebHost.UseUrls("http://0.0.0.0:5141", "https://0.0.0.0:7141");

// Add services
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<RSWDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👇 Add Authentication
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






var app = builder.Build();



// Middleware order is important
//app.UseHttpsRedirection();
app.UseAuthentication();  // 👈 Add this before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
