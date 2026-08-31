using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IEmpruntService
    {
        Task<List<EmpruntDto>?> GetAllActiveAsync();
        Task<bool> RetournerLivre(int empruntId, int userId);
    }
}
