using FastEndpoints;
using SummitSample.UserService.Contracts.Models;
using SummitSample.UserService.Contracts.Services;

namespace SummitSample.UserService.Endpoints;

public class GetUserEndpoint : EndpointWithoutRequest<UserModel>
{
	private readonly ISampleUserService _userService;

	public GetUserEndpoint( ISampleUserService userService )
	{
		_userService = userService;
	}

	public override void Configure()
	{
		Get( "/api/user/{id}" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( CancellationToken ct )
	{
		int id = Route<int>( "id" );
		UserModel? result = await _userService.GetUserAsync( id );
		if ( result is not null )
		{
			await Send.ResultAsync( TypedResults.Ok( result ) );
		}
		else
		{
			await Send.ResultAsync( TypedResults.NotFound() );
		}
	}
}
