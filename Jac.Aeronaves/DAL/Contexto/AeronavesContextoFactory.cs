using Jac.Aeronaves.DAL.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Jac.Aeronaves.DAL.Contexto
{
    public class AeronavesContextoFactory : IDesignTimeDbContextFactory<AeronavesContexto>

    {
        public AeronavesContexto CreateDbContext(string[] args)
        {
            //dotnet tool install--global dotnet-ef
            //dotnet tool update--global dotnet-ef
            //dotnet tool update 0 dotnet -ef (Borrar todas las migraciones)
            //dotnet ef migrations add InitialCreateLocal --context AeronavesContexto
            //dotnet ef database update --context AeronavesContexto

            var dbContextBuilder = new DbContextOptionsBuilder<AeronavesContexto>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Aeronaves; Integrated Security=True;";
            // var connectionString = "Server=tcp:servidormovies.database.windows.net,1433;Initial Catalog=mvcmoviebd;Persist Security Info=False;User ID=jacinto;Password=P0t@toP0t@to;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            dbContextBuilder.UseSqlServer(connectionString, sqloptions =>
            {
                sqloptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: new List<int>() { });
            });
            return new AeronavesContexto(dbContextBuilder.Options);
        }
    }
}
