using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummitSample.UserService.Contracts.Models;

public class UserModel
{
	public int Id { get; set; }

	public string LastName { get; set; } = null!;

	public string FirstName { get; set; } = null!;
}
