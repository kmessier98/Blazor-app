using AutoMapper;
using LibraryApp.Application.Interfaces;

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
        public async Task GetAuteurInfos(int auteurId)
        {
            await _auteurRepository.FindByIdAsync(auteurId);
        }
    }
}
