using Microsoft.EntityFrameworkCore;
using SummitSample.UserService.Contracts.DataObjects;
using SummitSample.UserService.Contracts.Repositories;
using SummitSample.UserService.Data.SqlServer.DataAccess.Context;
using SummitSample.UserService.Data.SqlServer.DataAccess.Entities;
using SummitSample.UserService.Data.SqlServer.Extensions;

namespace SummitSample.UserService.Data.SqlServer.Repositories;

public class SampleUserRepository : ISampleUserRepository
{
	private readonly UserDbContext _dataContext;

	public SampleUserRepository( UserDbContext dataContext )
	{
		_dataContext = dataContext;
	}

	private async Task InsertUserAsync(UserData userData )
	{
		User newUser = userData.ToUser();

		_ = await _dataContext.Users.AddAsync( newUser );
		_ = await _dataContext.SaveChangesAsync();
	}

	private async Task UpdateUserAsync(UserData userData )
	{
		User? currentUser = await _dataContext.Users.FirstOrDefaultAsync( u => u.Id == userData.Id );
		if (currentUser is null )
		{
			return;
		}
		userData.ToUser( currentUser );
		_ = await _dataContext.SaveChangesAsync();
	}

	public async Task<List<UserData>> GetUsersAsync()
	{
		List<User> users = await _dataContext.Users.OrderBy( u => u.LastName ).ThenBy( u => u.FirstName ).ToListAsync();
		List<UserData> result = users.ToUserData();

		return result;
	}

	public async Task<UserData?> GetUserAsync( int id )
	{
		User? user = await _dataContext.Users.FirstOrDefaultAsync( u => u.Id == id );

		if (user is null )
		{
			return null;
		}

		UserData result = user.ToUserData();

		return result;
	}

	public async Task StoreUserAsync( UserData user )
	{
		if (user.Id == 0)
		{
			await InsertUserAsync( user );
		}
		else
		{
			await UpdateUserAsync( user );
		}
	}
}
