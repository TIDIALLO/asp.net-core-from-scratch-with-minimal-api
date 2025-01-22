using GestionBibilotheque.Api.Dtos;

namespace GestionBibilotheque.Api.Enpoints;

using AutoMapper;
using GestionBibilotheque.Api.Data;
using GestionBibilotheque.Api.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Serilog;

public static class BookApiExtensions
{
    public static void MapBookApis(this WebApplication app)
    {
  
        app.MapGet("/books/{id}", async (int id, BookDbContext dbContext) =>
        {
            Log.Information($"La route '/books/{id}' a été appelée.");

            var book = await dbContext.Books!.FindAsync(id);
            if (book == null)
            {
                return Results.NotFound(new { Message = $"Book with ID {id} not found." });
            }
            return Results.Ok(book);
        });


        // Endpoint pour récupérer tous les livres
        app.MapGet("/books", async (BookDbContext dbContext) =>
        {
            var books = await dbContext.Books!.ToListAsync();
            return Results.Ok(books);
        });





        #region mappin avec AutoMapper

        app.MapPost("/books", async (CreateBookDto newBookDto, BookDbContext dbContext, IMapper mapper) =>
        {
            var newBook = mapper.Map<Book>(newBookDto);
            dbContext.Books!.Add(newBook);
                await dbContext.SaveChangesAsync();

            var bookResponseDto = mapper.Map<BookDto>(newBook);

            return Results.Created($"/books/{newBook.Id}", bookResponseDto);
        });
            
        #endregion

        // PUT API pour mettre à jour un livre
        #region Endpoint pour mettre à jour un livre 
 

        app.MapPut("/books/{id}", async (int id, CreateBookDto updatedBookDto, BookDbContext dbContext, IMapper mapper) =>
        {
            var existingBook = await dbContext.Books!.FindAsync(id);
            if (existingBook == null)
            { 
                return Results.NotFound(new { Message = $"Book with ID {id} not found." });
            }

            // Mise à jour des propriétés
            mapper.Map(updatedBookDto, existingBook);

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        #endregion
        // DELETE API pour supprimer un livre
        
        #region Endpoint pour supprimer un livre

        app.MapDelete("/books/{id}", async (int id, BookDbContext dbContext) =>
        {
            var book = await dbContext.Books!.FindAsync(id);
            if (book == null)
            {
                return Results.NotFound(new { Message = $"Book with ID {id} not found." });
            }

            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        #endregion 

    }
}
