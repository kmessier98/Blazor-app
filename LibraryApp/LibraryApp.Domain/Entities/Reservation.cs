using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities
{
    [Table("Reservation")]
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public StatutReservation Statut { get; set; } = StatutReservation.EnAttente;
        public int LivreId { get; set; }
        public Livre Livre { get; set; }
        public int MembreId { get; set; }
        public Membre Membre { get; set; }
    }

    public enum StatutReservation
    {
        EnAttente,
        Annulee,
        Complete
    }
}
