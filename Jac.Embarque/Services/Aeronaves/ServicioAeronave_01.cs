using Jac.Embarque.Models;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Jac.Embarque.Services.Aeronaves
{
    public class ServicioAeronave_01 : IServicioAeronave
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient cliente;
        private readonly IHttpClientFactory clientFactory;

        public ServicioAeronave_01(IHttpClientFactory httpClientFactory)
        {
            clientFactory= httpClientFactory;
            cliente= clientFactory.CreateClient();
            _options = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true
            };
            cliente.BaseAddress = new Uri("http://jac.aeronaves/api/Aeronaves/");

        }
        public async Task<List<Aeronave>?> DameTodos()
        {
            using HttpResponseMessage response = await cliente.GetAsync("DameTodos");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return await Task.Run(()=> System.Text.Json.JsonSerializer.Deserialize<List<Aeronave>>(jsonResponse, _options));
        }

        public Task<Aeronave?> GetAeronaveAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
