using System.ComponentModel.DataAnnotations;

namespace Mongocrud.Models
{
	public class UpdateSalaryByIdRequest
	{
		[Required]
		public string Id { get; set; }

		[Required]
		public int salary {  get; set; }
	}

	public class UpdateSalaryByIdResponse
	{

		public bool success { get; set; }

		public string message { get; set; }

	}
}
