using Jac.Tripulantes.DAL.Repositorio;
using Jac.Tripulantes.Services.TripulanteSpecification;

namespace Jac.Tripulantes
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
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddScoped<ITripulantesRepositorio, FakeRepositorio>();
                builder.Services.AddScoped<ITripulanteSpecification, IberiaTripulanteSpecification>();
            }
            else if (builder.Environment.IsProduction()) 
            {
                builder.Services.AddScoped<ITripulantesRepositorio, EFRepositorio>();
                builder.Services.AddScoped<ITripulanteSpecification, VuelingTripulanteSpecification>();
            }
            else
            {
                builder.Services.AddScoped<ITripulantesRepositorio, EFAzureDatabaseRepositorio>();
                builder.Services.AddScoped<ITripulanteSpecification, VuelingTripulanteSpecification>();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()
                || app.Environment.IsProduction()
                )
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