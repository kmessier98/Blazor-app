using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IEmpruntService
    {
        Task<EmpruntDto> Get(int id);
        Task<List<EmpruntDto>> GetAllActiveAsync();
        Task RetournerExemplaire(int empruntId);
        Task<EmpruntDto> EmprunterExemplaire(int exemplaireId, int membreId);
    }
}
