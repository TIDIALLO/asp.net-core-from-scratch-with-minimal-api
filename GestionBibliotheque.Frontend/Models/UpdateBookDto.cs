
namespace GestionBibliotheque.Frontend.Models
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateOnly DatePub { get; set; }
    }

}