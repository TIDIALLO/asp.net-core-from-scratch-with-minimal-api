namespace GestionBibliotheque.Frontend.Services;

using GestionBibliotheque.Frontend.Models;
using System.Net.Http.Json;

public class BookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Appeler l'API pour récupérer tous les livres
    public async Task<List<BookDto>> GetBooksAsync()
    {
        var books = await _httpClient.GetFromJsonAsync<List<BookDto>>("books");
        return books!;
    }

    // Appeler l'API pour ajouter un livre
    public async Task AddBookAsync(CreateBookDto newBook)
    {
        var response = await _httpClient.PostAsJsonAsync("books", newBook);
        response.EnsureSuccessStatusCode();
    }

    // Appeler l'API pour récupérer un livre par son Id
    public async Task<BookDto> GetBookByIdAsync(int id)
    {
        var book = await _httpClient.GetFromJsonAsync<BookDto>($"books/{id}");
        return book!    ;
    }

    // Appeler l'API pour mettre à jour un livre
    public async Task UpdateBookAsync(int id, UpdateBookDto updatedBook)
    {
        var response = await _httpClient.PutAsJsonAsync($"books/{id}", updatedBook);
        response.EnsureSuccessStatusCode();
    }

    // Appeler l'API pour supprimer un livre
    public async Task DeleteBookAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"books/{id}");
        response.EnsureSuccessStatusCode();
    }
}
