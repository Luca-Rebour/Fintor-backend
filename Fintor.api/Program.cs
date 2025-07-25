
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


namespace Fintor.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<FintorDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IPasswordService, PasswordService>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);

            //Inyeccion de dependencias de Repositories

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Inyeccion de dependencias UseCases de User
            builder.Services.AddScoped<ICreateUser, CreateUser>();

            //Inyeccion de dependencias UseCases de Auth
            builder.Services.AddScoped<ISignIn, SignIn>();

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
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
