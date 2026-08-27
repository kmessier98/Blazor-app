using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Editeur")]
    public class Editeur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }
}
