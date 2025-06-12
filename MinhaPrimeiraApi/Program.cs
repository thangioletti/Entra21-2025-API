using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.Infrastructure;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Services;

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
            builder.Services.AddScoped<IMecanicoService, MecanicoService>();
            builder.Services.AddTransient<IMecanicoRepository, MecanicoRepository>();

            builder.Services.AddSwaggerGen();


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
        }
    }
}