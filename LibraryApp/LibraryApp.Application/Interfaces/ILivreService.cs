using System;
using System.Collections.Generic;
using System.Text;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Application.Interfaces
{
    public interface ILivreService
    {
        public Task<List<GetAllLivresDto>> GetAll();
    }
}
