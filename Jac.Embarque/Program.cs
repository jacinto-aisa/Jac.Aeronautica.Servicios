using Jac.Embarque;
using Jac.Embarque.DAL.Repositorio;
using Jac.Embarque.Services.Aeronaves;
using Jac.Embarque.Services.Tripulantes;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IEmbarqueRepositorio, FakeRepositorio>();
        builder.Services.AddScoped<IServicioAeronave, ServicioAeronave_01>();
        builder.Services.AddScoped<IServicioTripulante, ServicioTripulantesInternacional>();
        builder.Services.AddHttpClient();

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