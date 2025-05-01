namespace SummitSample.Web.Models;

public class UserModel
{
	public int Id { get; set; }

	public string LastName { get; set; } = null!;

	public string FirstName { get; set; } = null!;

	public string FullName => $"{FirstName} {LastName}";
}
