using System.ComponentModel.DataAnnotations;

namespace Mongocrud.Models
{

	public class UpdateRecordByIdRequest
	{
		[Required]
		public string Id { get; set; }
	}
	public class UpdateRecordByIdResponse
	{
		
			public bool success { get; set; }

			public string message { get; set; }

			


		
	}
}
