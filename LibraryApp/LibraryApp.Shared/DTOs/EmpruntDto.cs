namespace LibraryApp.Shared.DTOs
{
    public class EmpruntDto
    {
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }
    }
}
