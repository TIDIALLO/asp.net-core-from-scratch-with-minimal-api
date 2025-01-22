namespace GestionBibliotheque.Blazor.Models;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime DatePub{ get; set; }
    //public string? Genre { get; set; }
}
