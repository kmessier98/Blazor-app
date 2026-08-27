using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
    }
}
