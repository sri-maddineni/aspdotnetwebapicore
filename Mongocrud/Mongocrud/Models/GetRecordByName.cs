namespace Mongocrud.Models
{
	public class GetRecordByNameResponse
	{
		public bool success { get; set; }

		public string message { get; set; }

		public InsertRecordRequest data { get; set; }


	}
}
