using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Application.Interfaces
{
    public interface IAuteurService
    {
        Task<GetAuteurInfosDto> GetAuteurInfos(int auteurId);
    }
}
