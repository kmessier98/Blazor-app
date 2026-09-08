using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IMembreService
    {
        Task<List<MembreDto>> GetAll();
        Task<MembreDto> Create(CreateMembreDto dto);
    }
}
