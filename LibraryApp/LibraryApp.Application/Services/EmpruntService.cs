using AutoMapper;
using LibraryApp.Application.Interfaces;

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

        public async Task GetAllActiveAsync()
        {
            await _empruntRepository.GetAllActiveAsync();
        }
    }
}
