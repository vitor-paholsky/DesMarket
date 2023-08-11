using DescontroladaMarket.Domain.Models;

namespace DescontroladaMarket.Web.WebServices;

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

    public async Task<Produtos> GetProduto(int id)
    {
        return await _httpClient.GetFromJsonAsync<Produtos>($"api/produtos/{id}");
    }

    public async Task<bool> UpdateProduto(Produtos produto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/produtos/{produto.Id}", produto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> AddProduto(Produtos produto)
    {
        var response = await _httpClient.PostAsJsonAsync("Create", produto);
        return response.IsSuccessStatusCode;
    }
}
