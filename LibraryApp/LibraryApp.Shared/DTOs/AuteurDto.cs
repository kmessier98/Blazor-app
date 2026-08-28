using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Shared.DTOs
{
    public class AuteurDto
    {
        public class GetAuteurInfosDto()
        {
            public int Id { get; set; }
            public string Prenom { get; set; }
            public string Nom { get; set; }
            public List<GetAllLivresDto> Livres { get; set; }
        }
    }
}
