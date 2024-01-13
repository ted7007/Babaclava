using Babaclava.Application.Book;
using Babaclava.Application.BookText;
using Babaclava.Core.Books;
using Babaclava.Core.BookText;
using Microsoft.Extensions.DependencyInjection;

namespace Babaclava.Application;

public static class DependencyExtensions
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookTextManager, BookTextManager>();
    }
}