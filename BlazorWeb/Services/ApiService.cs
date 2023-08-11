using DescontroladaMarket.Domain.Models;

namespace BlazorWeb.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Produtos>> GetProdutos()
    {
        return await _httpClient.GetFromJsonAsync<List<Produtos>>("api/produtos");
    }
}