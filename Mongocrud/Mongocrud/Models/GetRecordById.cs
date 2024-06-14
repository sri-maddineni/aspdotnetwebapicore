namespace Mongocrud.Models
{

	public class GetRecordByIdRequest
	{

	}
	public class GetRecordByIdResponse
	{
		public bool success { get; set; }

		public string message { get; set; }

		public InsertRecordRequest data { get; set; }
	}
}
