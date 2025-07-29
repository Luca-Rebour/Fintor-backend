
using Application.Interfaces.Services;
using AutoMapper;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Application.MappingProfiles;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;
using Application.Interfaces.UseCases.Users;
using Application.UseCases.Users;
using Api.Middlewares;
using Application.Interfaces.UseCases.Auth;
using Application.UseCases.Auth;
using Application.Interfaces.UseCases.Accounts;
using Application.UseCases.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;


namespace Fintor.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ESTO PERMITE USAR JWT EN SWAGGER, NO NECESARIO EN PRODUCCION
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fintor", Version = "v1" });

                // ?? Configurar soporte para JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT en este formato: Bearer {token}"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            // Configuracion de CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:4200") // URL del frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"]!)),
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddDbContext<FintorDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPasswordService, PasswordService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccountProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<MovementProfile>();
                cfg.AddProfile<RecurringMovementProfile>();
                cfg.AddProfile<UserProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            //Inyeccion de dependencias de Repositories

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            //Inyeccion de dependencias UseCases de User
            builder.Services.AddScoped<ICreateUser, CreateUser>();

            //Inyeccion de dependencias UseCases de Auth
            builder.Services.AddScoped<ISignIn, SignIn>();

            //Inyeccion de dependencias UseCases de Account
            builder.Services.AddScoped<ICreateAccount, CreateAccount>();
            builder.Services.AddScoped<IDeleteAccount, DeleteAccount>();
            builder.Services.AddScoped<IGetAllAccounts, GetAllAccounts>();


            //Inyeccion de dependencias Services
            builder.Services.AddScoped<IJwtService, JwtService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
