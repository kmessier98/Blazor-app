using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Exemplaire")]
    public class Exemplaire
    {
        public int Id { get; set; }
        public string CodeBarre { get; set; }
        public bool EstDisponible { get; set; }
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public List<Emprunt> Emprunts { get; set; }
    }
}
