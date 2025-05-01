
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

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

		ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

		app.UseFastEndpoints();

        app.Run();
    }
}
