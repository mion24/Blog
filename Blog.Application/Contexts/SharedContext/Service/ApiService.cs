using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Microsoft.JSInterop;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public ApiService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<T> SendRequestAsync<T>(HttpMethod method, string url, object data = null)
    {
        var _token = await _localStorageService.GetItemAsync<string>("token");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

        HttpResponseMessage response;

        switch (method.Method)
        {
            case "GET":
                response = await _httpClient.GetAsync(url);
                break;
            case "POST":
                response = await _httpClient.PostAsJsonAsync(url, data);
                break;
            case "PUT":
                response = await _httpClient.PutAsJsonAsync(url, data);
                break;
            case "DELETE":
                response = await _httpClient.DeleteAsync(url);
                break;
            default:
                throw new NotSupportedException($"HTTP method {method} not supported.");
        }

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }
        else
        {
            // Handle errors or return default value
            return default;
        }
    }
}
