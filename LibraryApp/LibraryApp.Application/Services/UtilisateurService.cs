using AutoMapper;
using LibraryApp.Application.Interfaces;

namespace LibraryApp.Application.Services
{
    public class UtilisateurService : IUtilisateurService
    {
        private readonly IMapper _mapper;
        private readonly IUtilisateurRepository _utilisateurRepository;

        public UtilisateurService(IMapper mapper, IUtilisateurRepository utilisateurRepository)
        {
            _mapper = mapper;
            _utilisateurRepository = utilisateurRepository;
        }

        public async Task GetAll()
        {
            await _utilisateurRepository.GetAllAsync();
        }
    }
}
