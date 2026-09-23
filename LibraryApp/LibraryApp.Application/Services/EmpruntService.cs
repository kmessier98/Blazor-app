using AutoMapper;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Shared.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Application.Services
{
    public class EmpruntService : IEmpruntService
    {
        private readonly IMapper _mapper;
        private readonly IEmpruntRepository _empruntRepository;
        private readonly ILivreRepository _livreRepository;
        private readonly IExemplaireRepository _exemplaireRepository;

        public EmpruntService(IMapper mapper, IEmpruntRepository empruntRepository, ILivreRepository livreRepository, IExemplaireRepository exemplaireRepository)
        {
            _mapper = mapper;
            _empruntRepository = empruntRepository;
            _livreRepository = livreRepository;
            _exemplaireRepository = exemplaireRepository;
        }

        public async Task<EmpruntDto> Get(int id)
        {
            var entity = await _empruntRepository.FindByIdAsync(id);
            if (entity is null)
                throw new NotFoundException(nameof(Emprunt), id);

            return _mapper.Map<EmpruntDto>(entity);
        }

        public async Task<List<EmpruntDto>> GetAllActiveAsync()
        {
            var result = await _empruntRepository.GetAllActiveAsync();

            var dto = _mapper.Map<List<EmpruntDto>>(result);

            return dto;
        }

        public async Task<EmpruntDto> EmprunterExemplaire(int exemplaireId, int membreId)
        {
            var exemplaire = await _exemplaireRepository.FindByIdAsync(exemplaireId);

            if (exemplaire is null)
            {
                throw new NotFoundException(nameof(Exemplaire), exemplaireId);
            }

            if (!exemplaire.EstDisponible)
            {
                throw new BusinessRuleException("Cet exemplaire n'est pas disponible pour un emprunt");
            }

            var aDejaUnEmpruntActifPourCeLivre = exemplaire.Livre.Exemplaires
                .SelectMany(e => e.Emprunts)
                .Any(e => e.MembreId == membreId && e.DateRetour == null);

            if (aDejaUnEmpruntActifPourCeLivre)
            {
                throw new BusinessRuleException("Le membre a déjà un emprunt en cours pour ce livre");
            }

            var empruntCreated = await _empruntRepository.EmprunterExemplaire(exemplaire, membreId);

            return _mapper.Map<EmpruntDto>(empruntCreated);
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
