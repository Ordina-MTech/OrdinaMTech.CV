using Microsoft.EntityFrameworkCore;
using OrdinaMTech.Cv.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var accountKey = "secret";
        
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<CvContext>(options => options
            .UseCosmos("https://cosmos-cv.documents.azure.com:443/"
            ,accountKey
            ,databaseName: "Cv")            
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors());
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddCors(policyBuilder =>
            policyBuilder.AddDefaultPolicy(policy =>
                policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader()));
        var app = builder.Build();

        CreateDbIfNotExists(app);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors();
        app.Run();
    }

    private static void CreateDbIfNotExists(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<CvContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}