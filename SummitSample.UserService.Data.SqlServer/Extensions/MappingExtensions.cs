using SummitSample.UserService.Common.Extensions;
using SummitSample.UserService.Contracts.DataObjects;
using SummitSample.UserService.Data.SqlServer.DataAccess.Entities;

namespace SummitSample.UserService.Data.SqlServer.Extensions;

internal static class MappingExtensions
{
	public static UserData ToUserData( this User user )
	{
		return new UserData
		{
			Id = user.Id,
			FirstName = user.FirstName,
			LastName = user.LastName
		};
	}

	public static List<UserData> ToUserData( this IEnumerable<User> users )
	{
		IEnumerable<User> enumerable = users.ToList();
		if ( !enumerable.Any() )
		{
			return [];
		}

		List<UserData> result = enumerable.WhereNotNull().Select( u => u.ToUserData() ).ToList();

		return result;
	}

	public static User ToUser( this UserData userData )
	{
		return new User
		{
			Id = userData.Id,
			FirstName = userData.FirstName,
			LastName = userData.LastName
		};
	}

	public static void ToUser(this UserData userData, User currentUser )
	{
		currentUser.FirstName = userData.FirstName;
		currentUser.LastName = userData.LastName;
	}
}
