using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface ILivreService
    {
        Task<List<GetAllLivresDto>> GetAllAsync();
        Task<GetLivreInfosDto?> GetLivreInfos(int livreId);
        Task<bool> EmprunterLivre(int livreId, int membreId);
    }
}
