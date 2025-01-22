using GestionBibliotheque.Blazor.Models;

namespace GestionBibliotheque.Blazor.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task CreateBookAsync(CreateBookDto newBook);
        Task UpdateBookAsync(int id, UpdateBookDto updatedBook);
        Task DeleteBookAsync(int id);
    }
}
