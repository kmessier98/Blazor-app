using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IMembreService
    {
        Task<List<MembreDto>> GetAll();
    }
}
