using LibraryApp.Client.Models;
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

        public async Task<ServiceResult<MembreDto>> Create(CreateMembreDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/membre", dto);

                if (response.IsSuccessStatusCode)
                {
                    var membre = await response.Content.ReadFromJsonAsync<MembreDto>();
                    return ServiceResult<MembreDto>.Success(membre!);
                }

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    return ServiceResult<MembreDto>.Failure(
                        errorContent?.Errors ?? ["Erreur de validation inconnue."]);
                }

                _logger.LogError("Erreur API {StatusCode} lors de la création du membre.", response.StatusCode);
                return ServiceResult<MembreDto>.Failure(["Une erreur est survenue sur le serveur."]);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return ServiceResult<MembreDto>.Failure(["Impossible de communiquer avec le serveur."]);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la création du membre.");
                return ServiceResult<MembreDto>.Failure(["Une erreur inattendue est survenue."]);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/membre/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la suppression du membre.");
                return false;
            }
        }

        public async Task<List<MembreDto>> GetAll()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<MembreDto>>("api/membre");

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
