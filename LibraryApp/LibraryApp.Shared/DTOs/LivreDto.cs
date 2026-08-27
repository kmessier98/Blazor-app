
namespace LibraryApp.Shared.DTOs
{
    public class LivreDTO
    {
        public class GetAllLivresDto()
        {
            public int LivreId { get; set; }
            public string Titre {  get; set; }
            public string NomAuteur { get; set; }
            public string PrenomAuteur { get; set; }
            public string NomEditeur { get; set; }
            public bool EstDisponible { get; set; }
        }
    }
}
