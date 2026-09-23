using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using System.Net.Http.Json;

namespace LibraryApp.Client.Services
{
    public class ExemplaireService : IExemplaireService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExemplaireService> _logger;

        public ExemplaireService(HttpClient httpClient, ILogger<ExemplaireService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ExemplaireDto?> EmprunterExemplaire(int exemplaireId, int membreId)
        {
            try
            {
                var request = new CreerEmpruntDto { ExemplaireId = exemplaireId, MembreId = membreId };
                var response = await _httpClient.PostAsJsonAsync("api/exemplaires/emprunts", request);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    _logger.LogWarning("Échec du retour ({StatusCode}): {Message}", response.StatusCode, errorMessage);
                    return null;
                }

                var exemplaire = await response.Content.ReadFromJsonAsync<ExemplaireDto>();
                return exemplaire;
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
