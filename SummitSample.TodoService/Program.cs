
using FastEndpoints;
using SummitSample.ServiceDefaults;

namespace SummitSample.TodoService;

public class Program
{

	public static void ConfigureServices(IServiceCollection services, IConfiguration configuration )
	{
		// Add services to the container.
		services.AddAuthorization();

		// Add FastEndpoints for RePR
		services.AddFastEndpoints();

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

		app.UseFastEndpoints();
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
