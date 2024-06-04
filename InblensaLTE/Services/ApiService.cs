using System.Net.Http.Json;
using Newtonsoft.Json;
using InblensaLTE.Models;

namespace InblensaLTE.Services;

public class ApiService
{
    public static string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7292/api/" : "https://localhost:7292/api/";

    private HttpClient _httpClient;

    public ApiService()
    {
        HttpClientHandler handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        _httpClient = new HttpClient(handler);
    }

    public async Task<AuthResponseModel> Login(LoginModel loginModel)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrl + "User/login", loginModel);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<AuthResponseModel>(await response.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Inventory>> GetInventories()
    {
        var response = await _httpClient.GetStringAsync(ApiUrl + "Inventory");
        return JsonConvert.DeserializeObject<List<Inventory>>(response);
    }
    
}