namespace Mongocrud.Models
{
	public class GetAllRecordResponse
	{
		public bool success { get; set; }

		public string message { get; set; }

		public List<InsertRecordRequest> data { get; set; }

	}
}
