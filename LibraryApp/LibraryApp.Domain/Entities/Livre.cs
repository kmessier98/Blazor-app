using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Livre")]
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public bool EstDisponible { get; set; }
        public int EditeurId { get; set; }
        public Editeur Editeur { get; set; }
        public List<Auteur> Auteurs { get; set; }
    }
}
