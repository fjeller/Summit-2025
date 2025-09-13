using FastEndpoints;
using SummitSample.TodoService.Contracts.Models;
using SummitSample.TodoService.Contracts.Services;

namespace SummitSample.TodoService.EndPoints;

public class GetTodoItemsEndpoint : EndpointWithoutRequest<List<TodoItemModel>>
{
	private readonly ISampleTodoService _todoService;

	public GetTodoItemsEndpoint( ISampleTodoService todoService )
	{
		_todoService = todoService;
	}

	public override void Configure()
	{
		Get( "/api/todoitems/{userId}" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( CancellationToken ct )
	{
		int userId = Route<int>( "userId" );
		List<TodoItemModel> result = await _todoService.GetTodoItemsAsync( userId );
		await Send.ResultAsync( TypedResults.Ok( result ) );
	}
}
