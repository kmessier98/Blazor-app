using LibraryApp.Shared.Enums;

namespace LibraryApp.Shared.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime DateReservation { get; set; }
        public StatutReservation Statut { get; set; }
        public int MembreId { get; set; }
        public int Position { get; set; }
    }

    public class CreateReservationDto
    {
        public int LivreId { get; set; }
        public int MembreId { get; set; }
    }
}
