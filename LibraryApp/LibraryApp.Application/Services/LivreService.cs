using AutoMapper;
using LibraryApp.Application.Exceptions;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
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

            if (result is null)
            {
                throw new NotFoundException(nameof(Livre), livreId);
            }

            var dto = _mapper.Map<GetLivreInfosDto>(result);

            return dto;

        }
    }
}
