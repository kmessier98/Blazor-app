using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface IAuteurService
    {
        Task<GetAuteurInfosDto?> GetAuteurInfos(int auteurId);
    }
}
