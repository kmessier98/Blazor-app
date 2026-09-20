namespace LibraryApp.Shared.DTOs
{
    public class ExemplaireDto
    {
        public int Id { get; set; }
        public string TiteLivre { get; set; }
        public string CodeBarre { get; set; }
        public bool EstDisponible { get; set; }
        public string EmpruntePar {  get; set; }
        public List<EmpruntDto> Emprunts { get; set; } = new List<EmpruntDto>();
    }
}
