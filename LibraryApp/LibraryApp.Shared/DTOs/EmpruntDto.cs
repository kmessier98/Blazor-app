namespace LibraryApp.Shared.DTOs
{
    public class EmpruntDto
    {
        public int Id { get; set; }
        public string TitreLivre { get; set; }
        public int MembreId { get; set; }
        public string NomMembre { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }
    }
}
