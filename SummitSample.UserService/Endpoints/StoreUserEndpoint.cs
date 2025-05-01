using FastEndpoints;
using SummitSample.UserService.Contracts.Models;
using SummitSample.UserService.Contracts.Services;

namespace SummitSample.UserService.Endpoints;

public class StoreUserEndpoint : Endpoint<UserModel>
{
	private readonly ISampleUserService _userService;

	public StoreUserEndpoint( ISampleUserService userService )
	{
		_userService = userService;
	}

	public override void Configure()
	{
		Post( "/api/users/store" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( UserModel req, CancellationToken ct )
	{
		await _userService.StoreUserAsync( req );
	}
}
