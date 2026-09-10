using LibraryApp.Client.Models;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IMembreService
    {
        Task<List<MembreDto>> GetAll();
        Task<ServiceResult<MembreDto>> Create(CreateMembreDto dto);
    }
}
