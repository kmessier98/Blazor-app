using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Application.Services
{
    public class EmpruntService : IEmpruntService
    {
        private readonly IMapper _mappper;
        private readonly IEmpruntRepository _empruntRepository;
        private readonly ILivreRepository _livreRepository;

        public EmpruntService(IMapper mapper, IEmpruntRepository empruntRepository, ILivreRepository livreRepository)
        {
            _mappper = mapper;
            _empruntRepository = empruntRepository;
            _livreRepository = livreRepository;
        }

        public async Task<List<EmpruntDto>> GetAllActiveAsync()
        {
            var result = await _empruntRepository.GetAllActiveAsync();

            var dto = _mappper.Map<List<EmpruntDto>>(result);

            return dto;
        }

        public async Task RetournerLivre(int empruntId, int membreId)
        {
            var emprunt = await _empruntRepository.GetActiveAsync(empruntId);

            if (emprunt == null) throw new ValidationException("Le livre que vous tentez de retourner n'existe pas ou n'est pas emprunté");
            if (emprunt.Livre.EstDisponible == true) throw new ValidationException("Le livre a déjà été retourné");
            if (emprunt.MembreId != membreId) throw new ValidationException("Vous n'êtes pas autorisé à retourner ce livre");

            await _empruntRepository.RetournerLivre(emprunt);
        }
    }
}
