using LibraryApp.Client.Models;
using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using System.Net.Http.Json;

namespace LibraryApp.Client.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MembreService> _logger;

        public ReservationService(HttpClient httpClient, ILogger<MembreService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ReservationDto?> Create(CreateReservationDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/reservations", dto);

                if (response.IsSuccessStatusCode)
                {
                    var reservation = await response.Content.ReadFromJsonAsync<ReservationDto>();
                    return reservation;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _logger.LogError("Erreur lors de la communication avec l'API : {Errors}", errorContent?.Errors is not null ? string.Join(", ", errorContent.Errors) : "Erreur lors de la communication avec l'API.");
                    return null;
                }

                _logger.LogError("Erreur API {StatusCode} lors de la création de la réservation.", response.StatusCode);
                return null;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la création du membre.");
                return null;
            }
        }

        public async Task<bool> Cancel(int reservationId)
        {
            try
            {
                var response = await _httpClient.PatchAsync($"api/reservations/{reservationId}/annuler", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
                    _logger.LogError("Erreur lors de la communication avec l'API : {Errors}", errorContent?.Errors is not null ? string.Join(", ", errorContent.Errors) : "Erreur lors de la communication avec l'API.");
                }

                _logger.LogError("Erreur API {StatusCode} lors de la création de la réservation.", response.StatusCode);
                return false;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erreur lors de la communication avec l'API.");
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Une erreur inattendue est survenue lors de la création du membre.");
                return false;
            }
        }
    }
}
