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

        public async Task RetournerExemplaire(int empruntId)
        {
            var emprunt = await _empruntRepository.GetActiveAsync(empruntId);

            if (emprunt == null) throw new ValidationException("L'exemplaire que vous tentez de retourner n'existe pas ou n'est pas emprunté");
            if (emprunt.Exemplaire.EstDisponible == true) throw new ValidationException($"L'exemplaire {emprunt.Exemplaire.CodeBarre} a déjà été retourné");

            await _empruntRepository.RetournerExemplaire(emprunt);
        }
    }
}
