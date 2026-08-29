using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;

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

        public async Task<List<UtilisateurDto>> GetAll()
        {
            var entity = await _utilisateurRepository.GetAllAsync();

            var dto = _mapper.Map<List<UtilisateurDto>>(entity);

            return dto;
        }
    }
}
