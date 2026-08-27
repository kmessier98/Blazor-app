namespace LibraryApp.Domain.Entities
{
    public class CategorieLivre
    {
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
