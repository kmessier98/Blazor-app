namespace LibraryApp.Shared.DTOs
{
    public class MembreDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
    }

    public class CreateMembreDto
    {
        public string Nom { get; set; }
        public string Courriel { get; set; }
    }
}
