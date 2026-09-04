using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Emprunt")]
    public class Emprunt
    {
        public int Id { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int MembreId { get; set; }
        public Membre Membre { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }
    }
}
