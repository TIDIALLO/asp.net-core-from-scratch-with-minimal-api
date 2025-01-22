
namespace GestionBibilotheque.Api.Dtos;

public record BookDto
{
    public int Id { get; set; }
    public string? Title { get; set; } 
    public string? Author { get; set; }
    public DateTime DatePub{ get; set; }
}
