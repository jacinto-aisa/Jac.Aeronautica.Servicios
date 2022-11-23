using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Jac.Tripulantes.DAL.Contexto
{
    public class TripulanteContextoFactory : IDesignTimeDbContextFactory<TripulanteContexto>

    {
        public TripulanteContexto CreateDbContext(string[] args)
        {
            //dotnet tool install--global dotnet-ef
            //dotnet tool update--global dotnet-ef
            //dotnet tool update 0 dotnet -ef
            //dotnet ef migrations add InitialCreateAzure--context JacintoContext
            //dotnet ef database update --context JacintoContext
            var dbContextBuilder = new DbContextOptionsBuilder<TripulanteContexto>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tripulantes; Integrated Security=True;";
            // var connectionString = "Server=tcp:servidormovies.database.windows.net,1433;Initial Catalog=mvcmoviebd;Persist Security Info=False;User ID=jacinto;Password=P0t@toP0t@to;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            dbContextBuilder.UseSqlServer(connectionString, sqloptions =>
            {
                sqloptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: new List<int>() { });
            });
            return new TripulanteContexto(dbContextBuilder.Options);
        }
    }
}
