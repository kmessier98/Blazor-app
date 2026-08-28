using AutoMapper;
using LibraryApp.Application.Interfaces;
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

            if (dto is null) throw new Exception(); // TODO return custom NotFoundException....

            return dto;
        }
    }
}
