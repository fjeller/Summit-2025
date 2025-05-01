namespace SummitSample.TodoService.Common.Extensions;

public static class EnumerableExtensions
{

	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> enumerable )
	{
		IEnumerable<T> result = enumerable.Where( e => e is not null ).Select( e => e! );

		return result;
	}

}
