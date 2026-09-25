namespace LibraryApp.Shared.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
    }

    public class CreateReservationDto
    {
        public int LivreId { get; set; }
        public int MembreId { get; set; }
    }
}
