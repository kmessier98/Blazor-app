using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto?> Create(CreateReservationDto dto);
        Task<bool> Cancel(int reservationId);
    }
}
