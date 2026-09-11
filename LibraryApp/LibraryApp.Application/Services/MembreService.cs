using AutoMapper;
using FluentValidation;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Services
{
    public class MembreService : IMembreService
    {
        private readonly IValidator<CreateMembreDto> _createValidator;
        private readonly IMapper _mapper;
        private readonly IMembreRepository _membreRepository;

        public MembreService(IValidator<CreateMembreDto> createValidator, IMapper mapper, IMembreRepository membreRepository)
        {
            _createValidator = createValidator;
            _mapper = mapper;
            _membreRepository = membreRepository;
        }

        public async Task<MembreDto> Create(CreateMembreDto dto)
        {
            var result = await _createValidator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            bool courrielExist = await _membreRepository.ExistsByCourrielAsync(dto.Courriel);
            if (courrielExist)
                throw new ConflictException("Le courriel est déjà utilisé pour un membre.");

            var entity = _mapper.Map<Membre>(dto);
            await _membreRepository.CreateAsync(entity); // entity.Id rempli après cet appel   

            return _mapper.Map<MembreDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _membreRepository.FindByIdAsync(id);
            if (entity is null)
                throw new NotFoundException(nameof(Membre), id);

            if (entity.Emprunts.Any(x => x.DateRetour == null))
                throw new ConflictException("Impossible de supprimer un membre avec des emprunts actifs.");

            await _membreRepository.DeleteAsync(entity);
        }

        public async Task<MembreDto> Get(int id)
        {
            var entity = await _membreRepository.FindByIdAsync(id);
            if (entity is null)
                throw new NotFoundException(nameof(Membre), id);

            return _mapper.Map<MembreDto>(entity);
        }

        public async Task<List<MembreDto>> GetAll()
        {
            var entity = await _membreRepository.GetAllAsync();

            var dto = _mapper.Map<List<MembreDto>>(entity);

            return dto;
        }
    }
}
