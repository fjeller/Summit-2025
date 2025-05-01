using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Contracts.Models;
using SummitSample.TodoService.Contracts.Repositories;
using SummitSample.TodoService.Contracts.Services;
using SummitSample.TodoService.Core.Extensions;

namespace SummitSample.TodoService.Core.Services;

public class SampleTodoService : ISampleTodoService
{
	private readonly ISampleTodoRepository _todoRepository;

	public SampleTodoService( ISampleTodoRepository todoRepository )
	{
		_todoRepository = todoRepository;
	}

	public async Task<List<TodoItemModel>> GetTodoItemsAsync( int userId )
	{
		var items = await _todoRepository.GetTodoItemsAsync( userId );
		var result = items.ToModel();

		return result;
	}

	public async Task<TodoItemModel?> GetTodoItemAsync( int id )
	{
		TodoItemData? item = await _todoRepository.GetTodoItemAsync( id );
		TodoItemModel? result = item?.ToModel();

		return result;
	}

	public async Task StoreTodoItemAsync( TodoItemModel model )
	{
		TodoItemData data = model.ToDataObject();
		await _todoRepository.StoreTodoItemAsync( data );
	}

	public async Task ToggleImportantAsync( int todoItemId )
	{
		await _todoRepository.ToggleImportantAsync( todoItemId );
	}

	public async Task ToggleCompletedAsync( int todoItemId )
	{
		await _todoRepository.ToggleCompletedAsync( todoItemId );
	}
}
