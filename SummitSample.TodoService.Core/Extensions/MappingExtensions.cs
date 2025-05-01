using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.TodoService.Common.Extensions;
using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Contracts.Models;

namespace SummitSample.TodoService.Core.Extensions;

internal static class MappingExtensions
{
	public static TodoItemModel? ToModel( this TodoItemData? data )
	{
		if (data is null )
		{
			return null;
		}

		return new TodoItemModel
		{
			Id = data.Id,
			UserId = data.UserId,
			Text = data.Text,
			IsCompleted = data.IsCompleted,
			IsImportant = data.IsImportant
		};
	}

	public static TodoItemData ToDataObject( this TodoItemModel data )
	{
		return new TodoItemData
		{
			Id = data.Id,
			UserId = data.UserId,
			Text = data.Text,
			IsCompleted = data.IsCompleted,
			IsImportant = data.IsImportant
		};
	}

	public static List<TodoItemModel> ToModel( this IEnumerable<TodoItemData> entities )
	{
		return entities.Select( entity => entity.ToModel() ).WhereNotNull().ToList();
	}
}
