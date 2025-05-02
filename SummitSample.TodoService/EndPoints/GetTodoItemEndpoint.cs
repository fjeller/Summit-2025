using FastEndpoints;
using SummitSample.TodoService.Contracts.Models;
using SummitSample.TodoService.Contracts.Services;

namespace SummitSample.TodoService.EndPoints;

public class GetTodoItemEndpoint : EndpointWithoutRequest<TodoItemModel>
{
	private readonly ISampleTodoService _todoService;

	public GetTodoItemEndpoint( ISampleTodoService todoService )
	{
		_todoService = todoService;
	}

	public override void Configure()
	{
		Get( "/api/todoitem/{id}" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( CancellationToken ct )
	{
		int id = Route<int>( "id" );
		TodoItemModel? result = await _todoService.GetTodoItemAsync( id );
		if ( result is not null )
		{
			await SendResultAsync( TypedResults.Ok( result ) );
		}
		else
		{
			await SendResultAsync( TypedResults.NotFound() );
		}
	}
}
