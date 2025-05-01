using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.UserService.Contracts.DataObjects;
using SummitSample.UserService.Contracts.Models;
using SummitSample.UserService.Contracts.Repositories;
using SummitSample.UserService.Contracts.Services;
using SummitSample.UserService.Core.Extensions;

namespace SummitSample.UserService.Core.Services;

public class SampleUserService : ISampleUserService
{
	private readonly ISampleUserRepository _repository;

	public SampleUserService( ISampleUserRepository repository )
	{
		_repository = repository;
	}

	public async Task<List<UserModel>> GetUsersAsync()
	{
		List<UserData> userDataItems = await _repository.GetUsersAsync();
		List<UserModel> result = userDataItems.ToUserModel();

		return result;
	}

	public async Task<UserModel?> GetUserAsync( int id )
	{
		UserData? userData = await _repository.GetUserAsync( id );
		UserModel? result = userData?.ToUserModel();

		return result;
	}

	public async Task StoreUserAsync( UserModel user )
	{
		UserData userData = user.ToUserData();
		await _repository.StoreUserAsync( userData );
	}
}
