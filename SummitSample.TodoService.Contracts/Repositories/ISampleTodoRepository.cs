using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Contracts.Models;

namespace SummitSample.TodoService.Contracts.Repositories;

public interface ISampleTodoRepository
{
	Task<List<TodoItemData>> GetTodoItemsAsync( int userId );

	Task<TodoItemData?> GetTodoItemAsync( int id );

	Task StoreTodoItemAsync( TodoItemData data );

	Task ToggleImportantAsync( int todoItemId );

	Task ToggleCompletedAsync( int todoItemId );
}
