using FastEndpoints;
using Microsoft.Extensions.Caching.Distributed;

namespace SummitSample.UserService.Endpoints;

public class GetGuidEndpoint : EndpointWithoutRequest
{
	private const string _CACHEKEY = "guidKey";

	private readonly IDistributedCache _cache;

	public GetGuidEndpoint( IDistributedCache cache )
	{
		_cache = cache;
	}

	public override void Configure()
	{
		Get( "/api/getguid" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( CancellationToken ct )
	{
		string? result = await _cache.GetStringAsync( _CACHEKEY, ct );

		if ( result is null )
		{
			result = Guid.CreateVersion7().ToString();
			await _cache.SetStringAsync( _CACHEKEY, result, ct );
		}

		await SendStringAsync( result, cancellation: ct );
	}
}
