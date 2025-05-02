using SummitSample.Web.Models;

namespace SummitSample.Web.ApiClients;

public class TodoApiClient
{
	private readonly HttpClient _httpClient;

	public TodoApiClient( HttpClient httpClient )
	{
		_httpClient = httpClient;
	}

	public async Task<List<TodoItemModel>> GetTodoItems( int userId )
	{
		List<TodoItemModel> result = await _httpClient.GetFromJsonAsync<List<TodoItemModel>>( $"/api/todoitems/{userId}" ) ?? [];

		return result;
	}

	public async Task<TodoItemModel?> GetTodoItem( int id )
	{
		TodoItemModel? result = await _httpClient.GetFromJsonAsync<TodoItemModel>( $"/api/todoitem/{id}" );

		return result;
	}

	public async Task StoreTodoItem(TodoItemModel item )
	{
		await _httpClient.PostAsJsonAsync( "/api/todoitem/store", item );
	}

	public async Task ToggleImportant( int id )
	{
		SingleIdRequestModel model = new() { Id = id };
		await _httpClient.PatchAsJsonAsync( $"/api/todoitem/toggleimportant", model );
	}

	public async Task ToggleCompleted(int id)
	{
		SingleIdRequestModel model = new() { Id = id };
		await _httpClient.PatchAsJsonAsync( $"/api/todoitem/togglecompleted", model );
	}
}
