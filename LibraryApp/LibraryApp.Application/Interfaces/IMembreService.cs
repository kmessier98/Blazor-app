using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IMembreService
    {
        Task<MembreDto> Get(int id);
        Task<List<MembreDto>> GetAll();
        Task<MembreDto> Create(CreateMembreDto dto);
    }
}
