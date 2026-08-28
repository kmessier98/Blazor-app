using System;
using System.Collections.Generic;
using System.Text;
using static LibraryApp.Shared.DTOs.CategoryDto;

namespace LibraryApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<GetAllCategoryDto>> GetAll();
    }
}
