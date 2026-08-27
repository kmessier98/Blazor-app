using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Emprunt")]
    public class Emprunt
    {
        public int Id { get; set; }
    }
}
