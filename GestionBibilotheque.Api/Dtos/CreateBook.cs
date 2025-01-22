namespace GestionBibilotheque.Api.Dtos
{
    public record CreateBookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime DatePub{ get; set; }
    }
}      