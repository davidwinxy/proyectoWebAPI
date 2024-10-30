using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductosWEB.Models;

namespace ProductosWEB.Services
{
    public class CompraService
    {
        private readonly HttpClient _httpClient;

        public CompraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Compra>> GetComprasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Compra>>("api/Compra");
        }

        public async Task<Compra> GetCompraById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Compra>($"api/Compra/{id}");
        }

        public async Task<Compra> CreateCompra(Compra compra)
        {
            // Calcular totales antes de enviar la compra
            compra.CalcularTotales();
            var response = await _httpClient.PostAsJsonAsync("api/Compra", compra);
            return await response.Content.ReadFromJsonAsync<Compra>();
        }

        public async Task UpdateCompra(Compra compra)
        {
            // Calcular totales antes de actualizar la compra
            compra.CalcularTotales();
            await _httpClient.PutAsJsonAsync($"api/Compra/{compra.Id}", compra);
        }

        public async Task DeleteCompra(int id)
        {
            await _httpClient.DeleteAsync($"api/Compra/{id}");
        }


        public async Task<List<Proveedor>> GetProveedoresAsync()
        {
            try
            {
                var proveedores = await _httpClient.GetFromJsonAsync<List<Proveedor>>("api/Proveedor");
                return proveedores ?? new List<Proveedor>(); // Asegúrate de devolver una lista vacía si es null
            }
            catch (Exception ex)
            {
                // Maneja el error, quizás logueándolo
                return new List<Proveedor>(); // Devolver una lista vacía en caso de error
            }
        }


    }
}