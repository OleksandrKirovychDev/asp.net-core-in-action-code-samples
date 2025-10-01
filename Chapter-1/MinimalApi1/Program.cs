using Microsoft.AspNetCore.HttpLogging;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);
        builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseHttpLogging();
        }

        app.MapGet("/", () => "Hello World!");
        app.MapGet("/person", () => new Person("Alex", "Alexovski"));
        app.Run();
    }
}

public record Person(String FirstName, String LastName);