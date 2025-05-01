using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.UserService.Contracts.DataObjects;
using SummitSample.UserService.Contracts.Models;

namespace SummitSample.UserService.Core.Extensions;
internal static class MappingExtensions
{
	public static UserModel ToUserModel( this UserData user )
	{
		return new UserModel
		{
			Id = user.Id,
			FirstName = user.FirstName,
			LastName = user.LastName
		};
	}

	public static List<UserModel> ToUserModel( this IEnumerable<UserData> users )
	{
		IEnumerable<UserData> enumerable = users.ToList();
		if ( !enumerable.Any() )
		{
			return [];
		}

		List<UserModel> result = enumerable.Select( u => u.ToUserModel() ).ToList();

		return result;
	}

	public static UserData ToUserData( this UserModel model )
	{
		return new UserData
		{
			Id = model.Id,
			FirstName = model.FirstName,
			LastName = model.LastName
		};
	}
}
