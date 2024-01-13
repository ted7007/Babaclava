using System.Reflection;
using Babaclava.Application;
using Babaclava.Infrastructure;
using Babaclava.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.RegisterApplication();
services.RegisterInfrastructure();

services.AddControllers();
var applicationAssembly = typeof(Babaclava.Application.DependencyExtensions).Assembly;
services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
services.AddSwaggerGen(options =>
{
    //
    // options.OperationFilter<AuthorizeCheckOperationFilter>();
    // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    // {
    //     Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
    //                   Enter 'Bearer' [space] and then your token in the text input below.
    //                   \r\n\r\nExample: 'Bearer 12345abcdef'",
    //     Name = "Authorization",
    //     In = ParameterLocation.Header,
    //     Type = SecuritySchemeType.ApiKey,
    //     Scheme = "Bearer"
    // });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();
var environment = app.Environment;
app.UseRouting();


app.UseCors(corsBuilder =>
{
    corsBuilder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials();
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpoints(config =>
{
    config.MapControllers();
    config.MapGet("ping", () => "pong");
});

switch (environment.EnvironmentName)
{
    case "Development":
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            DbContextSeed.Seed(scope.ServiceProvider, false);
        }

        break;
}

app.Run();