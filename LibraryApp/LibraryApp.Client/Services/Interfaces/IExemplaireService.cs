using LibraryApp.Client.Models;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IExemplaireService
    {
        Task<ExemplaireDto?> EmprunterExemplaire(int exemplaireId, int membreId);
    }
}
