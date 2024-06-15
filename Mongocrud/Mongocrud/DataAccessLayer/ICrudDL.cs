using Mongocrud.Models;

namespace Mongocrud.DataAccessLayer
{
	public interface ICrudDL
	{
		public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest req);
		public Task<GetAllRecordResponse> GetAllRecord();

		public Task<GetRecordByIdResponse> GetRecordById(string Id);

		public Task<GetRecordByNameResponse> GetRecordByName(string Name);

		public Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest req);

		public Task<UpdateSalaryByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest req);

		public Task<DeleteRecordByIdResponse>DeleteRecordById(string Id);

		public Task<UpdateSalaryByIdResponse> DeleteAllRecord();

	}
}
