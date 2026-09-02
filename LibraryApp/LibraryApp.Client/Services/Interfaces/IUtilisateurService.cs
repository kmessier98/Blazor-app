using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IUtilisateurService
    {
        Task<List<UtilisateurDto>?> GetAll();
    }
}
