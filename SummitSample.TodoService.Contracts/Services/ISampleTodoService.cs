using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Contracts.Models;

namespace SummitSample.TodoService.Contracts.Services;

public interface ISampleTodoService
{
	Task<List<TodoItemModel>> GetTodoItemsAsync( int userId );

	Task<TodoItemModel?> GetTodoItemAsync( int id );

	Task StoreTodoItemAsync( TodoItemModel model );

	Task ToggleImportantAsync( int todoItemId );

	Task ToggleCompletedAsync( int todoItemId );
}
