using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationDto> Get(int id);
        Task<ReservationDto> Create(CreateReservationDto dto);
        Task Cancel(int id);
    }
}
