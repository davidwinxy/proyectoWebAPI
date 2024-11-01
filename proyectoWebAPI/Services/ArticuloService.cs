using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductosWEB.Models;

namespace proyectoWebAPI.Services
{
    public class ArticuloService
    {
        private readonly HttpClient _httpClient;

        public ArticuloService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Articulo>> GetArticulosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Articulo>>("api/Articulo");
        }

        public async Task<Articulo> GetArticuloById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Articulo>($"api/Articulo/{id}");
        }

        public async Task<Articulo> CreateArticulo(Articulo articulo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Articulo", articulo);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Articulo>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear proveedor: {response.StatusCode} - {errorContent}");
            }
        }

        // Actualizar un artículo existente
        public async Task UpdateArticulo(Articulo articulo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Articulo/{articulo.Id}", articulo);

            if (!response.IsSuccessStatusCode)
            {
                // Manejo de errores: lanzar excepción o manejar el error según sea necesario
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el articulo: {response.StatusCode} - {errorContent}");
            }
        }

        // Eliminar un artículo por ID
        public async Task DeleteArticulo(int id)
        {
            await _httpClient.DeleteAsync($"api/Articulo/{id}");
        }
    }
}