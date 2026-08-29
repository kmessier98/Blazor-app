using AutoMapper;
using LibraryApp.Application.Interfaces;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Application.Services
{
    public class LivreService : ILivreService
    {
        private ILivreRepository _livreRepository;
        private IEmpruntRepository _empruntRepository;
        private readonly IMapper _mapper;
        public LivreService(IMapper mapper, ILivreRepository livreRepository, IEmpruntRepository empruntRepository)
        {
            _mapper = mapper;
            _livreRepository = livreRepository;
            _empruntRepository = empruntRepository; 
        }

        public async Task<List<GetAllLivresDto>> GetAll()
        {
            var result = await _livreRepository.GetAllAsync();

            var dto = _mapper.Map<List<GetAllLivresDto>>(result);
            return dto;
        }

        public async Task<GetLivreInfosDto> GetLivreInfos(int livreId)
        {
            var result = await _livreRepository.FindByIdAsync(livreId);

            if (result is null) throw new Exception(); // TODO custom exception NotFound

            var dto = _mapper.Map<GetLivreInfosDto>(result);

            return dto;
        }

        public async Task EmprunterLivre(int livreId, int utilisateurId)
        {
            var currentLivre = await _livreRepository.FindByIdAsync(livreId);

            if (currentLivre is null) throw new Exception(); // TODO custom exception NotFound
                                                     
            // Sécurité si le livre pour X ou y raison il est déjà emprunté...
            if (!currentLivre.EstDisponible)
            {
                throw new InvalidOperationException("Le livre n'est pas disponible pour un emprunt");
            }
            //Sécurité supplémentaire
            var empruntExistant = await _empruntRepository.GetActiveAsync(livreId);
            if (empruntExistant != null)
            {
                throw new InvalidOperationException("Ce livre a déjà un emprunt actif");
            }

            await _livreRepository.EmprunterLivre(currentLivre, utilisateurId);
        }
    }
}
