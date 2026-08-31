
using static LibraryApp.Shared.DTOs.CategoryDto;

namespace LibraryApp.Shared.DTOs
{
    public class LivreDto
    {
        public class GetAllLivresDto()
        {
            public int LivreId { get; set; }
            public string Titre { get; set; }
            public int AuteurId { get; set; }
            public string NomAuteur { get; set; }
            public string PrenomAuteur { get; set; }
            public string NomEditeur { get; set; }
            public bool EstDisponible { get; set; }
            public List<int> CategoryIds { get; set; }
        }

        public class GetLivreInfosDto()
        {
            public int LivreId { get; set; }
            public string Titre { get; set; }
            public int AuteurId { get; set; }
            public string NomAuteur { get; set; }
            public string PrenomAuteur { get; set; }
            public string NomEditeur { get; set; }
            public bool EstDisponible { get; set; }
            public List<GetAllCategoryDto> Categories { get; set; }
            public List<EmpruntDto> Emprunts { get; set; }

        }
    }
}
