using LibraryApp.Client.Services.Interfaces;
using System.Net.Http.Json;
using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Client.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuteurService> _logger;

        public AuteurService(HttpClient httpClient, ILogger<AuteurService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<GetAuteurInfosDto?> GetAuteurInfos(int auteurId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<GetAuteurInfosDto>($"api/auteur/GetAuteurInfos/{auteurId}");

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
