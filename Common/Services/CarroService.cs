using Newtonsoft.Json;
using tpSw04.Models;
using System.Net;


namespace Common.Services
{
    public class CarroService
    {
        private string baseUrl;
        private HttpClient client;
        public CarroService(string baseUrl, HttpClient client)
        {
            this.client = client;
            this.baseUrl = baseUrl;
        }

        public async Task<List<Carro>> GetAll()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Carros");

            var response = await client.SendAsync(request);

            var Carros = JsonConvert.DeserializeObject<List<Carro>>(await response.Content.ReadAsStringAsync());
            return Carros;
        }

        public async Task<Carro> GetById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/Carros/{id}");

            var response = await client.SendAsync(request);

            var Carro = JsonConvert.DeserializeObject<Carro>(await response.Content.ReadAsStringAsync());

            return Carro;
        }

        public async Task<bool> Create(Carro Carro)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/Carros");

            var content = JsonConvert.SerializeObject(Carro);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> Update(int id, Carro Carro)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/Carros/{id}");

            var content = JsonConvert.SerializeObject(Carro);

            request.Content = new StringContent(content, null, "application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<bool> Delete(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}/Carros/{id}");

            var response = await client.SendAsync(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

    }
}