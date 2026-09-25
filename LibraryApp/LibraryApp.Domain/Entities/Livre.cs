using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Livre")]
    public class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int EditeurId { get; set; }
        public Editeur Editeur { get; set; }
        public List<Auteur> Auteurs { get; set; }
        public List<Categorie> Categories { get; set; }
        public List<Exemplaire> Exemplaires { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
