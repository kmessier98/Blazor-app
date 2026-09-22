using AutoMapper;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Services
{
    public class ExemplaireService : IExemplaireService
    {
        private readonly IExemplaireRepository _exemplaireRepository;
        private readonly IMapper _mapper;

        public ExemplaireService(IExemplaireRepository exemplaireRepository, IMapper mapper)
        {
            _exemplaireRepository = exemplaireRepository;
            _mapper = mapper;
        }

        public async Task<ExemplaireDto> Get(int id)
        {
            var exemplaire = await _exemplaireRepository.FindByIdAsync(id);

            if (exemplaire is null)
            {
                throw new NotFoundException(nameof(Exemplaire), id);
            }

            return _mapper.Map<ExemplaireDto>(exemplaire);
        }

        public async Task<ExemplaireDto> EmprunterExemplaire(int exemplaireId, int membreId)
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

            await _exemplaireRepository.EmprunterExemplaire(exemplaire, membreId);

            return _mapper.Map<ExemplaireDto>(exemplaire);
        }
    }
}
