using FastEndpoints;
using SummitSample.UserService.Contracts.Models;
using SummitSample.UserService.Contracts.Services;

namespace SummitSample.UserService.Endpoints;

public class GetUsersEndpoint : EndpointWithoutRequest<List<UserModel>>
{
	private readonly ISampleUserService _userService;

	public GetUsersEndpoint( ISampleUserService userService )
	{
		_userService = userService;
	}

	public override void Configure()
	{
		Get( "/api/users" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( CancellationToken ct )
	{
		List<UserModel> result = await _userService.GetUsersAsync();
		await SendResultAsync( TypedResults.Ok( result ) );
	}
}
