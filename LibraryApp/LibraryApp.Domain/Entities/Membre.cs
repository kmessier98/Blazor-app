using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Membre")]
    public class Membre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public List<Emprunt> Emprunts { get; set; }
    }
}
