using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IEmpruntService
    {
        Task<List<EmpruntDto>> GetAllActiveAsync();
    }
}
