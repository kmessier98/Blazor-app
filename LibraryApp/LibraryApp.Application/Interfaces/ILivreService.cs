using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Application.Interfaces
{
    public interface ILivreService
    {
        Task<List<GetAllLivresDto>> GetAll();
        Task<GetLivreInfosDto> GetLivreInfos(int livreId);
        Task EmprunterLivre(int livreId, int membreId);
    }
}
