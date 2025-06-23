using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.Infrastructure;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Services;
using System.Text;

namespace MinhaPrimeiraApi
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

            //DEPENDENCIA
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IAuthentication, Authentication>();
            builder.Services.AddScoped<IMecanicoService, MecanicoService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMecanicoRepository, MecanicoRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            //ADIÇÃO DO BEARER NO SWAGGER 
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() {}
                    }
                });
            });

            var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);


            //ADD JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}