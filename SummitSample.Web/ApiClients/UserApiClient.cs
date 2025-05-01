using SummitSample.Web.Models;

namespace SummitSample.Web.ApiClients;

public class UserApiClient
{
	private readonly HttpClient _httpClient;

	public UserApiClient( HttpClient httpClient )
	{
		_httpClient = httpClient;
	}

	public async Task<List<UserModel>> GetUsersAsync()
	{
		List<UserModel> users = await _httpClient.GetFromJsonAsync<List<UserModel>>( "/api/users" ) ?? [];
		return users;
	}

	public async Task<UserModel?> GetUserAsync( int id )
	{
		UserModel? result = await _httpClient.GetFromJsonAsync<UserModel>( $"/api/user/{id}" );
		return result ?? null;
	}

	public async Task StoreUserAsync(UserModel model )
	{
		await _httpClient.PostAsJsonAsync( "/api/users/store", model );
	}
}
