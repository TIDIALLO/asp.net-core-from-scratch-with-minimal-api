
using GestionBibilotheque.Api.Dtos;
using GestionBibilotheque.Api.Entities;

namespace GestionBibilotheque.Api.Mappings;
public static class BookMappingExtension
{
    public static Book ToEntity(this CreateBookDto book)
    {
        return new Book()
        {
            Title = book.Title!,
            Author = book.Author!,
            DatePub = book.DatePub
        };
    } 

    public static CreateBookDto ToDto(this Book book)
    {
       return new CreateBookDto
        {
            Title = book.Title,
            Author = book.Author,
            DatePub = book.DatePub
        };
    }
}
