using FastEndpoints;
using SummitSample.TodoService.Contracts.RequestModels;
using SummitSample.TodoService.Contracts.Services;

namespace SummitSample.TodoService.EndPoints;

public class ToggleCompletedEndpoint : Endpoint<SingleIdRequestModel, EmptyResponse>
{
	private readonly ISampleTodoService _todoService;

	public ToggleCompletedEndpoint( ISampleTodoService todoService )
	{
		_todoService = todoService;
	}

	public override void Configure()
	{
		Patch( "/api/todoitem/togglecompleted" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( SingleIdRequestModel req, CancellationToken ct )
	{
		await _todoService.ToggleCompletedAsync( req.Id );
		await SendAsync( new EmptyResponse(), cancellation: ct );
	}
}
