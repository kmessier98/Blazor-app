using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Infrastructure;
using System.Net.Http.Json;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Services
{
    public class LivreService : ILivreService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<LivreService> _logger;

        public LivreService(HttpClient httpClient, ILogger<LivreService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<GetAllLivresDto>?> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<GetAllLivresDto>>("api/livre/GetAll");

                return response;
            }
            catch (HttpRequestException ex)
            {
                // Erreur réseau ou code HTTP d'erreur (ex: 404, 500)
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return null;
            }
            catch (Exception ex) 
            {
                // Tout autre type d'erreur imprévue
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la récupération des données.");
                return null;
            }
        }
    }
}
