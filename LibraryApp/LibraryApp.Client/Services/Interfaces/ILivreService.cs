using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface ILivreService
    {
        Task<List<GetAllLivresDto>?> GetAllAsync();
    }
}
