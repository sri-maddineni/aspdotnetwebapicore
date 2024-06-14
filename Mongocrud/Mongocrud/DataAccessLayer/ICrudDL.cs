using Mongocrud.Models;

namespace Mongocrud.DataAccessLayer
{
	public interface ICrudDL
	{
		public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest req);
		public Task<GetAllRecordResponse> GetAllRecord();

		public Task<GetRecordByIdResponse> GetRecordById(string Id);

		public Task<GetRecordByNameResponse> GetRecordByName(string Name);
	}
}
