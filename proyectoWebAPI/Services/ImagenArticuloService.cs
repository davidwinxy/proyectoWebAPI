using ProductosWEB.Models;
using proyectoWebAPI.Models;
using System.Net.Http;

namespace proyectoWebAPI.Services
{
    public class ImagenArticuloService
    {
        private readonly HttpClient _httpClient;

        public ImagenArticuloService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ImagenArticulo>> GetArticulosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ImagenArticulo>>("api/ImagenArticulo");
        }

        // Obtener un artículo por ID
        public async Task<ImagenArticulo> GetArticuloById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ImagenArticulo>($"api/ImagenArticulo/{id}");
        }


        public async Task<bool> UploadImagenAsync(int articuloId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false; // O maneja el error como prefieras
            }

            using var content = new MultipartFormDataContent();
            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);
            stream.Position = 0; // Reiniciar el stream para que se lea desde el inicio

            var fileContent = new ByteArrayContent(stream.ToArray());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

            content.Add(fileContent, "file", file.FileName);
            content.Add(new StringContent(articuloId.ToString()), "articuloId"); // Agregar el ID del artículo

            var response = await _httpClient.PostAsync("api/ImagenArticulo", content);
            return response.IsSuccessStatusCode;
        }

    }
}
