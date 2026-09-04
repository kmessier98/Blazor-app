using AutoMapper;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Application.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly IMapper _mapper;
        private readonly IAuteurRepository _auteurRepository;

        public AuteurService(IMapper mapper, IAuteurRepository auteurRepository)
        {
            _mapper = mapper;
            _auteurRepository = auteurRepository;
        }
        public async Task<GetAuteurInfosDto> GetAuteurInfos(int auteurId)
        {
            var result = await _auteurRepository.FindByIdAsync(auteurId);
            var dto = _mapper.Map<GetAuteurInfosDto>(result);

            if (dto is null)
            {
                throw new NotFoundException(nameof(Auteur), auteurId);
            }

            return dto;
        }
    }
}
