using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class ProveedorService
{
    private readonly HttpClient _httpClient;

    public ProveedorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Proveedor>> GetProveedoresAsync(){
        return await _httpClient.GetFromJsonAsync<List<Proveedor>>("api/Proveedor");
    }

    public async Task<Proveedor> GetProveedorById(int id){
        return await _httpClient.GetFromJsonAsync<Proveedor>($"api/Proveedor/{id}");
    }

    public async Task<Proveedor> CreateProveedor(Proveedor proveedor)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Proveedor", proveedor);

        // Verificar si la respuesta fue exitosa
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Proveedor>();
        }
        else
        {
            // Manejo de errores: podrías lanzar una excepción o devolver un valor nulo, según sea necesario
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al crear proveedor: {response.StatusCode} - {errorContent}");
        }
    }

    public async Task UpdateProveedor(Proveedor proveedor)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Proveedor/{proveedor.Id}", proveedor);

        if (!response.IsSuccessStatusCode)
        {
            // Manejo de errores: lanzar excepción o manejar el error según sea necesario
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al actualizar proveedor: {response.StatusCode} - {errorContent}");
        }
    }

    public async Task DeleteProveedor(int id){
        await _httpClient.DeleteAsync($"api/Proveedor/{id}");
    }
}
