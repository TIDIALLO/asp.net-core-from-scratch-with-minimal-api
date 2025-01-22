using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.Blazor.Models
{
   public record UpdateBookDto
    {
        [Required(ErrorMessage = "Le titre est requis")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'auteur est requis")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "La date de publication est requise")]
        public DateTime DatePub { get; set; }
    }
}