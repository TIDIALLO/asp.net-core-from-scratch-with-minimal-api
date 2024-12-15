
using AutoMapper;
using GestionBibilotheque.Api.Dtos;
using GestionBibilotheque.Api.Entities;

namespace GestionBibilotheque.Api.Mappings;

public class BookMapping : Profile
{
    public BookMapping()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>();
    }
}
