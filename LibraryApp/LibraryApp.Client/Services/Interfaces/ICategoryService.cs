using static LibraryApp.Shared.DTOs.CategoryDto;

namespace LibraryApp.Client.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoryDto>> GetAllAsync();
    }
}
