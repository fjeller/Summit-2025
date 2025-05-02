using FastEndpoints;
using SummitSample.TodoService.Contracts.RequestModels;
using SummitSample.TodoService.Contracts.Services;

namespace SummitSample.TodoService.EndPoints;

public class ToggleImportantEndpoint : Endpoint<SingleIdRequestModel, EmptyResponse>
{
	private readonly ISampleTodoService _todoService;

	public ToggleImportantEndpoint( ISampleTodoService todoService )
	{
		_todoService = todoService;
	}

	public override void Configure()
	{
		Patch( "/api/todoitem/toggleimportant" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( SingleIdRequestModel req, CancellationToken ct )
	{
		await _todoService.ToggleImportantAsync( req.Id );
		await SendAsync( new EmptyResponse(), cancellation: ct );
	}
}
