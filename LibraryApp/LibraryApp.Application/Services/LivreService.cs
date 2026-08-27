using LibraryApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Services
{
    public class LivreService : ILivreService
    {
        private ILivreRepository _livreRepository;
        public LivreService(ILivreRepository livreRepository)
        {
            _livreRepository = livreRepository;
        }

        public async Task GetAll()
        {
            var result = await _livreRepository.GetAllAsync();
            
        }
    }
}
