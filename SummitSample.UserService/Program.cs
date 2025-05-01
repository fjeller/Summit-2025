
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SummitSample.ServiceDefaults;
using SummitSample.UserService.Contracts.Repositories;
using SummitSample.UserService.Contracts.Services;
using SummitSample.UserService.Core.Services;
using SummitSample.UserService.Data.SqlServer.DataAccess.Context;
using SummitSample.UserService.Data.SqlServer.Repositories;

namespace SummitSample.UserService;

public class Program
{

	public static WebApplication ApplyMigrations( WebApplication app )
	{
		using ( var scope = app.Services.CreateScope() )
		{
			UserDbContext dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
			ILogger logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

			// Check and apply pending migrations
			IEnumerable<string> pendingMigrations = dbContext.Database.GetPendingMigrations();
			if ( pendingMigrations.Any() )
			{
				logger.LogInformation( "{Classname}.{Methodname}: Pending migrations found, applying migrations ...",
					nameof( Program ),
					nameof( ApplyMigrations ) );

				dbContext.Database.Migrate();

				logger.LogInformation( "{Classname}.{Methodname}: Migrations applied successfully.",
					nameof( Program ),
					nameof( ApplyMigrations ) );
			}
			else
			{
				logger.LogInformation( "{Classname}.{Methodname}: No pending migrations found in the database.",
					nameof( Program ),
					nameof( ApplyMigrations ) );
			}
		}

		return app;
	}

	private static void ConfigureServices(IServiceCollection services, IConfiguration configuration )
	{
		// Add FastEndpoints
		services.AddFastEndpoints();

		// Add services to the container.
		services.AddAuthorization();

		string? connectionString = configuration.GetConnectionString( "DefaultConnection" );
		services.AddDbContext<UserDbContext>( o => o.UseSqlServer( connectionString ) );

		// add services and Repositories
		services.AddScoped<ISampleUserRepository, SampleUserRepository>();
		services.AddScoped<ISampleUserService, SampleUserService>();

		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		services.AddOpenApi();
	}

	private static void ConfigurePipeline(WebApplication app )
	{
		app.MapDefaultEndpoints();

		// Configure the HTTP request pipeline.
		if ( app.Environment.IsDevelopment() )
		{
			app.MapOpenApi();
		}

		ApplyMigrations( app );

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.UseFastEndpoints();
	}

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

		ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

		ConfigurePipeline( app );

        app.Run();
    }
}
