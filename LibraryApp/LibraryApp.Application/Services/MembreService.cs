using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Services
{
    public class MembreService : IMembreService
    {
        private readonly IMapper _mapper;
        private readonly IMembreRepository _membreRepository;

        public MembreService(IMapper mapper, IMembreRepository membreRepository)
        {
            _mapper = mapper;
            _membreRepository = membreRepository;
        }

        public async Task<List<MembreDto>> GetAll()
        {
            var entity = await _membreRepository.GetAllAsync();

            var dto = _mapper.Map<List<MembreDto>>(entity);

            return dto;
        }
    }
}
