using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IEmpruntService
    {
        Task<List<EmpruntDto>> GetAllActiveAsync();
        Task<bool> RetournerExemplaire(int empruntId);
        Task<EmpruntDto?> EmprunterExemplaire(int exemplaireId, int membreId);
    }
}
