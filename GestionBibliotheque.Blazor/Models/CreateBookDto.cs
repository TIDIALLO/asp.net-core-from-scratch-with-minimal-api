using System.ComponentModel.DataAnnotations;

namespace GestionBibliotheque.Blazor.Models;

 public record CreateBookDto
    {
        [Required(ErrorMessage = "Le titre est requis")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "L'auteur est requis")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "La date de publication est requise")]
        public DateTime DatePub { get; set; }
    }