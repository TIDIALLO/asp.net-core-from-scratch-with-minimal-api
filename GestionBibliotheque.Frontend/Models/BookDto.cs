

namespace GestionBibliotheque.Frontend.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateOnly DatePub { get; set; }
    }

}