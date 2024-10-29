using System;
using ProductosWEB.Models;

namespace ProductosWEB.Services;

public class UsuarioServices
{
    private readonly HttpClient _httpClient;

    public UsuarioServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>> GetUsuariosAsync(){
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuario");
    }

    public async Task<Usuario> GetUsuarioById(int id)
    {
        // Asegúrate de que la URL es correcta
        var response = await _httpClient.GetAsync($"api/Usuario/{id}");
        response.EnsureSuccessStatusCode(); // Esto lanzará una excepción si el código de estado no es 2xx
        return await response.Content.ReadFromJsonAsync<Usuario>();
    }

    public async Task<Usuario> CreateUsuario(Usuario usuario){
        var response = await _httpClient.PatchAsJsonAsync("api/Usuario", usuario);
        return await response.Content.ReadFromJsonAsync<Usuario>();
    }

    public async Task UpdateUsuario(Usuario usuario){
        await _httpClient.PutAsJsonAsync($"api/Usuario/{usuario.Id}", usuario);
    }

    public async Task DeleteUsuario(int id){
        await _httpClient.DeleteAsync($"api/Usuario/{id}");
    }

}
