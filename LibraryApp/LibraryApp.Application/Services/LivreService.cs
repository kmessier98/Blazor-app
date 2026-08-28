using AutoMapper;
using LibraryApp.Application.Interfaces;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Application.Services
{
    public class LivreService : ILivreService
    {
        private ILivreRepository _livreRepository;
        private readonly IMapper _mapper;
        public LivreService(IMapper mapper, ILivreRepository livreRepository)
        {
            _mapper = mapper;
            _livreRepository = livreRepository;
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
    }
}
