using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using SummitSample.ServiceDefaults;
using SummitSample.TodoService.Contracts.Repositories;
using SummitSample.TodoService.Contracts.Services;
using SummitSample.TodoService.Core.Services;
using SummitSample.TodoService.Data.SqlServer.DataAccess.Context;
using SummitSample.TodoService.Data.SqlServer.Repositories;

namespace SummitSample.TodoService;

public class Program
{

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration )
	{
		// Add services to the container.
		services.AddAuthorization();

		// Add FastEndpoints for RePR
		services.AddFastEndpoints().SwaggerDocument(); 

		string? connectionString = configuration.GetConnectionString( "DefaultConnection" );
		if ( String.IsNullOrWhiteSpace( connectionString ) )
		{
			throw new InvalidOperationException( "The connectionstring is not valid" );
		}
		services.AddDbContext<TodoDbContext>( o => o.UseSqlServer( connectionString ) );

		services.AddScoped<ISampleTodoRepository, SampleTodoRepository>();
		services.AddScoped<ISampleTodoService, SampleTodoService>();

		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		services.AddOpenApi();
	}

	public static void ConfigurePipeline(WebApplication app )
	{
		app.MapDefaultEndpoints();

		// Configure the HTTP request pipeline.
		if ( app.Environment.IsDevelopment() )
		{
			app.MapOpenApi();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.UseFastEndpoints().UseSwaggerGen(); 
	}


    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

		ConfigureServices( builder.Services, builder.Configuration );

        var app = builder.Build();

		ConfigurePipeline( app );

        app.Run();
    }
}
