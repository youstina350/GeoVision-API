using GeoVision.API.Middleware;
using GeoVision.Application.Configurations;
using GeoVision.Application.Interfaces;
using GeoVision.Application.Interfaces.External;
using GeoVision.Application.Services;
using GeoVision.Core.Interfaces;
using GeoVision.Infrastructure.Integrations.Earthquake;
using GeoVision.Infrastructure.Integrations.Eonet;
using GeoVision.Infrastructure.Integrations.Nasa;
using GeoVision.Infrastructure.Integrations.Weather;
using GeoVision.Infrastructure.Persistence;
using GeoVision.Infrastructure.Repositories;
using GeoVision.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GeoVision
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //////////////////////////////////////////////////////////////
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactPolicy", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Register DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependency Injection
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            // Http Clients
            builder.Services.Configure<NasaApiOptions>(
                builder.Configuration.GetSection(NasaApiOptions.SectionName));

            builder.Services.AddHttpClient<INasaService, NasaService>((serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<NasaApiOptions>>()
                    .Value;

                client.BaseAddress = new Uri(options.BaseUrl);
            });

            builder.Services.Configure<EonetApiOptions>(
                builder.Configuration.GetSection(EonetApiOptions.SectionName));

            builder.Services.AddHttpClient<IEonetService, EonetService>(client =>
            {
                client.BaseAddress = new Uri(
                    builder.Configuration["EonetApi:BaseUrl"]!);
            });

            // 👇 تم إضافة تسجيل خدمة الطقس هنا لحل مشكلة الـ Dependency Injection
            builder.Services.AddHttpClient<IWeatherService, WeatherService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["WeatherApi:BaseUrl"] ?? "https://api.weatherapi.com/v1/");
            });

            // Add services to the container.
            builder.Services.AddControllers();

            // Options Pattern
            builder.Services.Configure<WeatherApiOptions>(
                builder.Configuration.GetSection(WeatherApiOptions.SectionName));

            builder.Services.Configure<NasaApiOptions>(
                builder.Configuration.GetSection(NasaApiOptions.SectionName));

            // Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                        )
                    };
                });

            builder.Services.Configure<UsgsApiOptions>(
                builder.Configuration.GetSection(UsgsApiOptions.SectionName));

            builder.Services.AddHttpClient<IEarthquakeService, EarthquakeService>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["UsgsApi:BaseUrl"]!);
            });

            // Swagger
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GeoVision API",
                    Version = "v1"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT Token like: Bearer {your token}"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseCors("ReactPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}