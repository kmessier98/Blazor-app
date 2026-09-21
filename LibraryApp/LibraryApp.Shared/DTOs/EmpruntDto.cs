namespace LibraryApp.Shared.DTOs
{
    public class EmpruntDto
    {
        public int Id { get; set; }
        public int MembreId { get; set; }
        public string NomMembre { get; set; }
        public string TitreLivreEmprunte { get; set; }
        public string CodeBarreLivreEmprunte { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }
    }
}
