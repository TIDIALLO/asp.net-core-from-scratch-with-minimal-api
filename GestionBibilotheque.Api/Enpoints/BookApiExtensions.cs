using GestionBibilotheque.Api.Dtos;

namespace GestionBibilotheque.Api.Enpoints;

using AutoMapper;
using GestionBibilotheque.Api.Data;
using GestionBibilotheque.Api.Entities;
using GestionBibilotheque.Api.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

public static class BookApiExtensions
{
    public static void MapBookApis(this WebApplication app)
    {
        List<BookDto> books = new List<BookDto>
        {
            new BookDto
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                DatePub = new DateOnly(2008, 8, 1)
            },
            new BookDto
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt, David Thomas",
                DatePub = new DateOnly(1999, 10, 20)
            },
            new BookDto
            {
                Id = 3,
                Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                DatePub = new DateOnly(1994, 10, 31)
            }
        };

        // Endpoint pour récupérer un livre par son ID
        /*    app.MapGet("/books/{id}", (int id) =>
            {
                var book = books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return Results.NotFound(new { Message = $"Le livre avec l'Id {id} n'existe pas." });
                }
                return Results.Ok(book);
            });
    */
        app.MapGet("/books/{id}", async (int id, BookDbContext dbContext) =>
        {
            var book = await dbContext.Books!.FindAsync(id);
            if (book == null)
            {
                return Results.NotFound(new { Message = $"Book with ID {id} not found." });
            }
            return Results.Ok(book);
        });


        // Endpoint pour récupérer tous les livres
        // app.MapGet("/books", () => books);
        app.MapGet("/books", async (BookDbContext dbContext) =>
        {
            var books = await dbContext.Books!.ToListAsync();
            return Results.Ok(books);
        });

        // POST API pour ajouter un nouveau livre
        /*      app.MapPost("/books", (BookDto newBook) =>
                   {
                       int newId = books.Any() ? books.Max(b => b.Id) + 1 : 1;

                       var bookToAdd = new BookDto
                       {
                           Id = newId,
                           Title = newBook.Title,
                           Author = newBook.Author,
                           DatePub = newBook.DatePub
                       };

                       books.Add(bookToAdd);
                       return Results.Created($"/books/{newId}", bookToAdd);
                   });
           */

            // POST API pour ajouter un nouveau livre dans la base de données
            #region  creér sans le mapping  
            /*      app.MapPost("/books", async (CreateBookDto newBookDto, BookDbContext dbContext) =>
                {
                    // Créer une nouvelle entité Book à partir du DTO
                    Book newBook = new Book
                    {
                        Title = newBookDto.Title!,
                        Author = newBookDto.Author!,
                        DatePub = newBookDto.DatePub
                    };

                    // Ajouter le livre à la base de données
                    dbContext.Books!.Add(newBook);
                    await dbContext.SaveChangesAsync();

                    // Retourner un DTO de répohnse au client
                    var bookResponseDto = new BookDto
                    {
                        Id = newBook.Id, *
                        Title = newBook.Title,
                        Author = newBook.Author,
                        DatePub = newBook.DatePub
                    };
                    // Retourner le résultat avec l'ID généré
                    return Results.Created($"/books/{newBook.Id}", bookResponseDto);
                });
        */ 

        #endregion

        #region Ajouter notre propre mapping avec des méthodes d'extensions ToEntity et ToDto
        app.MapPost("/books", async (CreateBookDto newBookDto, BookDbContext dbContext) =>
        {
            // Mapper le DTO vers l'entité
            var newBook = newBookDto.ToEntity();

            // Ajouter l'entité çà la base de données
            dbContext.Books!.Add(newBook);
            await dbContext.SaveChangesAsync();

            // Mapper l'enwtité sauvegardée vers un DTO de réponse
            var bookResponseDto = newBook.ToDto();

            // Retourner la réponse
            return Results.Created($"/books/{newBook.Id}", bookResponseDto);
        });

        #endregion


        #region mappin avec AutoMapper
        /*
            app.MapPost("/books", async (CreateBookDto newBookDto, BookDbContext dbContext, IMapper mapper) =>
                { 
                    var newBook = mapper.Map<Book>(newBookDto);
                    dbContext.Books!.Add(newBook);
                    await dbContext.SaveChangesAsync();

                    var bookResponseDto = mapper.Map<BookDto>(newBook);
          
                    return Results.Created($"/books/{new Book.Id}", bookResponseDto);
                })
            */
        #endregion

        // PUT API pour mettre à jour un livre
        #region Endpoint pour mettre à jour un livre 
        /* app.MapPut("/books/{id}", (int id, UpdateBook updatedBook) =>
         {
             var book = books.FirstOrDefault(b => b.Id == id);

             if (book == null)
             {
                 return Results.NotFound();
             }

             book.Title = updatedBook.Title ?? book.Title;
             book.Author = updatedBook.Author ?? book.Author;
             book.DatePub = updatedBook.DatePub != default ? updatedBook.DatePub : book.DatePub;

             return Results.NoContent();
         });
         */

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
        /* app.MapDelete("/books/{id}", (int id) =>
         {
             var book = books.FirstOrDefault(b => b.Id == id);
             if (book == null)
             {
                 return Results.NotFound();
             }

             books.Remove(book);
             return Results.NoContent();
         });
     */
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
