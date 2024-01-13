using Babaclava.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Babaclava.Infrastructure.Data;

public class DbContextSeed
{
    private static bool _isDockerEnabled = false;
    public static void Seed(IServiceProvider provider, bool isDockerEnabled)
    {
        _isDockerEnabled = isDockerEnabled;
        var environment = provider.GetService<IHostEnvironment>();

        var dbContext = provider.GetService<BabaclavaDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
        
        dbContext.Books.AddRange(ReadFromFile<Book>("Books", environment));
        dbContext.Users.AddRange(ReadFromFile<User>("Users", environment));
        dbContext.UserResults.AddRange(ReadFromFile<UserResult>("UserResults", environment));
        dbContext.SaveChanges();

    }
    
    
    private static IEnumerable<T> ReadFromFile<T>(string seedFileName, IHostEnvironment environment)
    {
        var directoryPath = Path.Combine(environment.ContentRootPath, "Seed");
        if(!_isDockerEnabled)
            directoryPath = Path.Combine(Directory.GetParent(environment.ContentRootPath).FullName, "Babaclava.Infrastructure", "Seed");
        var dataString = File.ReadAllText(Path.Combine(directoryPath, $"{seedFileName}.json"));
        var data = JsonConvert.DeserializeObject<List<T>>(dataString);

        if (data is null)
            throw new ArgumentNullException(nameof(data));
        return data;
    }
}