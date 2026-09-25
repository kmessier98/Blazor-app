using AutoMapper;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly ILivreRepository _livreRepository;
        private readonly IMembreRepository _membreRepository;

        public ReservationService(IMapper mapper, IReservationRepository reservationRepository, ILivreRepository livreRepository, IMembreRepository membreRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _livreRepository = livreRepository;
            _membreRepository = membreRepository;
        }

        public async Task<ReservationDto> Get(int id)
        {
            var entity = _reservationRepository.FindByIdAsync(id);
            if (entity is null)
                throw new NotFoundException(nameof(entity), id);

            return _mapper.Map<ReservationDto>(entity);
        }


        public async Task<ReservationDto> Create(CreateReservationDto dto)
        {
            var livre = await _livreRepository.FindByIdAsync(dto.LivreId);
            if (livre is null)
                throw new NotFoundException(nameof(livre), dto.LivreId);

            var membre = await _membreRepository.FindByIdAsync(dto.MembreId);
            if (membre is null)
                throw new NotFoundException(nameof(membre), dto.MembreId);

            if (livre.Exemplaires.Any(x => x.EstDisponible))
                throw new BusinessRuleException("Impossible de faire une réservation. Il y a au moins un exemplaire de disponible");

            if (membre.Reservations.Any(x => x.LivreId == dto.LivreId && x.Statut == Domain.Entities.StatutReservation.EnAttente))
                throw new BusinessRuleException("Impossible de faire une réservation. Ce membre a déjà une réservation pour ce livre.");

            if (membre.Emprunts.Any(x => x.DateRetour == null && x.Exemplaire.LivreId == dto.LivreId))
                throw new BusinessRuleException("Impossible de faire une réservation. Ce membre a déjà un emprunt en cours pour ce livre");

            var entity = new Reservation
            {
                DateReservation = DateTime.Now,
                Statut = StatutReservation.EnAttente,
                LivreId = dto.LivreId,
                MembreId = membre.Id,
            };

            await _reservationRepository.CreateAsync(entity);

            return _mapper.Map<ReservationDto>(entity);
        }

        public async Task Cancel(int reservationId)
        {
            var reservation = await _reservationRepository.FindByIdAsync(reservationId);
            if (reservation is null)
                throw new NotFoundException(nameof(reservation), reservationId);

            if (reservation.Statut != StatutReservation.EnAttente)
                throw new BusinessRuleException("Impossible d'annuler cette réservation, elle n'est plus en attente.");

            await _reservationRepository.Cancel(reservation);
        }

    }
}
