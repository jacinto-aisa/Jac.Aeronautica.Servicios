using Jac.Embarque.Models;
using System.Net.Http;
using System.Text.Json;

namespace Jac.Embarque.Services.Tripulantes
{
    public class ServicioTripulantesInternacional : IServicioTripulante
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient cliente;
        private readonly IHttpClientFactory clientFactory;

        public ServicioTripulantesInternacional(IHttpClientFactory httpClientFactory)
        {
            clientFactory = httpClientFactory;
            cliente = clientFactory.CreateClient();
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            cliente.BaseAddress = new Uri("http://localhost:5100/api/Tripulantes/");

        }

        public async Task<List<Categoria>?> DameTodasLasCategorias()
        {
            using HttpResponseMessage response = await cliente.GetAsync("DameTodasCategorias");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (jsonResponse is not null)
                return await Task.Run(() => JsonSerializer.Deserialize<List<Categoria>>(jsonResponse, _options));
            return null;
        }

        public async Task<List<Tripulante>?> DameTodosTripulantes()
        {
            using HttpResponseMessage response = await cliente.GetAsync("DameTodosTripulantes");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (jsonResponse is not null)
                return await Task.Run(() => JsonSerializer.Deserialize<List<Tripulante>>(jsonResponse, _options));
            return null;
        }

        public Task<Categoria?> GetCategoriaAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Tripulante?> GetTripulanteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TripulanteConCategoria?> GetTripulanteConCategoria(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
