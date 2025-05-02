namespace SummitSample.Web.Models;

public class TodoItemModel
{
	public int Id { get; set; }

	public int UserId { get; set; }

	public string Text { get; set; } = null!;

	public bool IsCompleted { get; set; }

	public bool IsImportant { get; set; }
}
