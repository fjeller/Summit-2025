using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.UserService.Contracts.DataObjects;
using SummitSample.UserService.Contracts.Models;

namespace SummitSample.UserService.Contracts.Services;

public interface ISampleUserService
{
	Task<List<UserModel>> GetUsersAsync();

	Task<UserModel?> GetUserAsync( int id );

	Task StoreUserAsync( UserModel user );
}
