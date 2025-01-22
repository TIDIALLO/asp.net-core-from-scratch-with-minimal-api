using GestionBibliotheque.Blazor.Models;
using System.Net.Http.Json;

namespace GestionBibliotheque.Blazor.Services;
public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookDto>> GetBooksAsync()
    {
        var books = await _httpClient.GetFromJsonAsync<List<BookDto>>("/books");
        return books ?? new List<BookDto>();
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<BookDto>($"/books/{id}");
    }

    public async Task CreateBookAsync(CreateBookDto newBook)
    {
        //await _httpClient.PostAsJsonAsync("/books", newBook);
        var response = await _httpClient.PostAsJsonAsync("/books", newBook);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateBookAsync(int id, UpdateBookDto updatedBook)
    {
        var response = await _httpClient.PutAsJsonAsync($"/books/{id}", updatedBook);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBookAsync(int id)
    {
        await _httpClient.DeleteAsync($"/books/{id}");
    }

}