using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.UserService.Contracts.DataObjects;

namespace SummitSample.UserService.Contracts.Repositories;

public interface ISampleUserRepository
{
	Task<List<UserData>> GetUsersAsync();

	Task<UserData?> GetUserAsync( int id );

	Task StoreUserAsync( UserData user );
}
