using Jac.Aeronaves.DAL.Repositorio;
using Jac.Aeronaves.Services.AeronavesSpecification;

namespace Jac.Aeronave
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
            builder.Services.AddScoped<IAeronaveSpecification, IberiaAeronaveSpecification>();
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddScoped<IAeronavesRepositorio, FakeRepositorio>();
            }
            else
            {
                builder.Services.AddScoped<IAeronavesRepositorio, EFRepositorio>();
            }

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}