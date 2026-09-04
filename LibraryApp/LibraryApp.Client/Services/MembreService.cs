using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using System.Net.Http.Json;

namespace LibraryApp.Client.Services
{
    public class MembreService : IMembreService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MembreService> _logger;

        public MembreService(HttpClient httpClient, ILogger<MembreService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<MembreDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<MembreDto>>("api/membre/GetAll");

                return response ?? [];
            }
            catch (HttpRequestException ex)
            {
                // Erreur réseau ou code HTTP d'erreur (ex: 404, 500)
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return [];
            }
            catch (Exception ex)
            {
                // Tout autre type d'erreur imprévue
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la récupération des données.");
                return [];
            }
        }
    }
}
