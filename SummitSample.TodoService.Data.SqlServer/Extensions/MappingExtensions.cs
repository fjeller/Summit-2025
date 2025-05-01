using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummitSample.TodoService.Common.Extensions;
using SummitSample.TodoService.Contracts.DataObjects;
using SummitSample.TodoService.Data.SqlServer.DataAccess.Entities;

namespace SummitSample.TodoService.Data.SqlServer.Extensions;
internal static class MappingExtensions
{
	// Map from TodoItem to TodoItemData
	public static TodoItemData? ToDataObject( this TodoItem? entity )
	{
		if (entity is null )
		{
			return null;
		}

		return new TodoItemData
		{
			Id = entity.Id,
			UserId = entity.UserId,
			Text = entity.Text,
			IsCompleted = entity.IsCompleted,
			IsImportant = entity.IsImportant
		};
	}

	public static List<TodoItemData> ToDataObject( this IEnumerable<TodoItem> entities )
	{
		return entities.Select( entity => entity.ToDataObject() ).WhereNotNull().ToList();
	}

	// Map from TodoItemData to TodoItem
	public static TodoItem ToEntity( this TodoItemData data )
	{
		return new TodoItem
		{
			Id = data.Id,
			UserId = data.UserId,
			Text = data.Text,
			IsCompleted = data.IsCompleted,
			IsImportant = data.IsImportant
		};
	}

	public static void ToEntity(this TodoItemData data, TodoItem entity )
	{
		entity.IsCompleted = data.IsCompleted;
		entity.IsImportant = data.IsImportant;
		entity.Text = data.Text;
	}

}
