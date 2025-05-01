using Microsoft.EntityFrameworkCore;
using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Contracts.Repositories;
using SummitSample.TodoService.Data.SqlServer.DataAccess.Context;
using SummitSample.TodoService.Data.SqlServer.DataAccess.Entities;
using SummitSample.TodoService.Data.SqlServer.Extensions;

namespace SummitSample.TodoService.Data.SqlServer.Repositories;

public class SampleTodoRepository : ISampleTodoRepository
{
	private readonly TodoDbContext _dataContext;

	public SampleTodoRepository( TodoDbContext dataContext )
	{
		_dataContext = dataContext;
	}

	private async Task InsertTodoItemAsync(TodoItemData data )
	{
		TodoItem newItem = data.ToEntity();

		_ = await _dataContext.TodoItems.AddAsync( newItem );
		_ = await _dataContext.SaveChangesAsync();
	}

	private async Task UpdateTodoItemAsync(TodoItemData data )
	{
		TodoItem? currentItem = await _dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == data.Id );
		if (currentItem == null )
		{
			return;
		}

		data.ToEntity( currentItem );
		_ = await _dataContext.SaveChangesAsync();
	}

	public async Task<List<TodoItemData>> GetTodoItemsAsync( int userId )
	{
		List<TodoItem> items = await _dataContext.TodoItems.Where( i => i.UserId == userId ).ToListAsync();
		List<TodoItemData> result = items.ToDataObject();

		return result;
	}

	public async Task<TodoItemData?> GetTodoItemAsync( int id )
	{
		TodoItem? item = await _dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == id );
		TodoItemData? result = item.ToDataObject();

		return result;
	}

	public async Task StoreTodoItemAsync( TodoItemData data )
	{
		if (data.Id == 0 )
		{
			await InsertTodoItemAsync( data );
		}
		else
		{
			await UpdateTodoItemAsync( data );
		}
	}

	public async Task ToggleImportantAsync( int todoItemId )
	{
		TodoItem? item = await _dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == todoItemId );
		if (item is null )
		{
			return;
		}

		item.IsImportant = !item.IsImportant;
		_ = await _dataContext.SaveChangesAsync();
	}

	public async Task ToggleCompletedAsync( int todoItemId )
	{
		TodoItem? item = await _dataContext.TodoItems.FirstOrDefaultAsync( i => i.Id == todoItemId );
		if ( item is null )
		{
			return;
		}

		item.IsCompleted = !item.IsCompleted;
		_ = await _dataContext.SaveChangesAsync();
	}
}
