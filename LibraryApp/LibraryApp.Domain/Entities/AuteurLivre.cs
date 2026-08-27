namespace LibraryApp.Domain.Entities
{
    public class AuteurLivre
    {
        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }

    }
}
