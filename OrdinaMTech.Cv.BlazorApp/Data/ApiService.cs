using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrdinaMTech.Cv.BlazorApp.Data
{
    public class ApiService
    {
        public HttpClient _httpClient;

        public ApiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<Cv.Shared.Models.Cv> GetCvAsync()
        {
            var response = await _httpClient.GetAsync("cv");
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            var jsonReader = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<Cv.Shared.Models.Cv>(jsonReader);
        }

        public async Task<HttpResponseMessage> UploadFotoAsync(HttpContent file)
        {
            var response = await _httpClient.PostAsync("/Cv/personalia/foto/upload", file);
            return response;
        }
    }
}
