using FastEndpoints;
using SummitSample.TodoService.Contracts.Models;
using SummitSample.TodoService.Contracts.Services;

namespace SummitSample.TodoService.EndPoints;

public class StoreTodoItemEndpoint : Endpoint<TodoItemModel>
{
	private readonly ISampleTodoService _todoService;

	public StoreTodoItemEndpoint( ISampleTodoService todoService )
	{
		_todoService = todoService;
	}

	public override void Configure()
	{
		Post( "/api/todoitem/store" );
		AllowAnonymous();
	}

	public override async Task HandleAsync( TodoItemModel req, CancellationToken ct )
	{
		await _todoService.StoreTodoItemAsync( req );
	}
}
