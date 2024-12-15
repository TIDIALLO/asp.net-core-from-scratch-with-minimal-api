
namespace GestionBibilotheque.Api.Dtos
{
    public record UpdateBook
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly DatePub { get; set; }
    }
}