namespace LibraryApp.Domain.Entities
{
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public bool EstDisponible { get; set; }
        public int EditeurId { get; set; }
        public Editeur Editeur { get; set; }
    }
}
