using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Interfaces
{
    public interface IExemplaireService
    {
        Task<ExemplaireDto> Get(int id);
        Task<ExemplaireDto> EmprunterExemplaire(int exemplaireId, int membreId);
    }
}
