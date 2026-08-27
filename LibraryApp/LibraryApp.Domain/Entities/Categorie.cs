using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Categorie")]
    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Livre> Livres { get; set; }
    }
}
