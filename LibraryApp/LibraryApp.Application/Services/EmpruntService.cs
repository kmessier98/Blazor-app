using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;

namespace LibraryApp.Application.Services
{
    public class EmpruntService : IEmpruntService
    {
        private readonly IMapper _mappper;
        private readonly IEmpruntRepository _empruntRepository;

        public EmpruntService(IMapper mapper, IEmpruntRepository empruntRepository)
        {
            _mappper = mapper;
            _empruntRepository = empruntRepository;
        }

        public async Task<List<EmpruntDto>> GetAllActiveAsync()
        {
            var result = await _empruntRepository.GetAllActiveAsync();

            var dto = _mappper.Map<List<EmpruntDto>>(result);

            return dto;
        }
    }
}
