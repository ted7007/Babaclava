using Babaclava.Core.Books;
using Babaclava.Infrastructure.Data;
using Babaclava.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Babaclava.Infrastructure;

public static class DependencyExtensions
{
    public static void RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<BabaclavaDbContext>(options => options.UseSqlite("Data Source = babaclava.db"));
        
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserResultRepository, UserResultRepository>();
    }
}