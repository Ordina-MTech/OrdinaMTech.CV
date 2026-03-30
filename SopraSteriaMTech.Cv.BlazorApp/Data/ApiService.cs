namespace SopraSteriaMTech.Cv.BlazorApp.Data;

public class ApiService
{
    public HttpClient _httpClient;

    public ApiService(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task<Cv.Data.Models.Cv> GetCvAsync()
    {
        var response = await _httpClient.GetAsync("cv");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Cv.Data.Models.Cv>();
    }

    public async Task<HttpResponseMessage> UploadFotoAsync(HttpContent file)
    {
        var response = await _httpClient.PostAsync("/Cv/personalia/foto/upload", file);
        return response;
    }
}
