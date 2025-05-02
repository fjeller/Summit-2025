using Radzen;
using SummitSample.ServiceDefaults;
using SummitSample.Web.ApiClients;
using SummitSample.Web.Components;

namespace SummitSample.Web;

public class Program
{
	public static void Configure( IServiceCollection services, IConfiguration configuration )
	{
		services.AddRazorComponents()
			.AddInteractiveServerComponents();

		// Add the radzen components that I use here
		services.AddRadzenComponents();

		services.AddOutputCache();

		// This URL uses "https+http://" to indicate HTTPS is preferred over HTTP - but both work
		services.AddHttpClient<UserApiClient>( client => client.BaseAddress = new Uri( "https+http://userservice" ) );
		services.AddHttpClient<TodoApiClient>( client => client.BaseAddress = new Uri( "https+http://todoservice" ) );
	}

	public static void ConfigurePipeline( WebApplication app )
	{
		if ( !app.Environment.IsDevelopment() )
		{
			app.UseExceptionHandler( "/Error", createScopeForErrors: true );
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseAntiforgery();

		app.UseOutputCache();

		app.MapStaticAssets();

		app.MapRazorComponents<App>()
			.AddInteractiveServerRenderMode();

		app.MapDefaultEndpoints();
	}

	public static void Main( string[] args )
	{
		var builder = WebApplication.CreateBuilder( args );

		// Add service defaults & Aspire client integrations.
		builder.AddServiceDefaults();

		// Add services to the container.
		Configure( builder.Services, builder.Configuration );

		var app = builder.Build();

		// Configure the pipeline
		ConfigurePipeline( app );

		app.Run();
	}
}




