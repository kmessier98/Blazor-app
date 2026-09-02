using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using System.Net.Http.Json;

namespace LibraryApp.Client.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UtilisateurService> _logger;

        public UtilisateurService(HttpClient httpClient, ILogger<UtilisateurService> logger)
        {
            _httpClient = httpClient; 
            _logger = logger;
        }
        public async Task<List<UtilisateurDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<UtilisateurDto>>("api/utilisateur/GetAll");

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
