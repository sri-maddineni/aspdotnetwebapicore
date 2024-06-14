using Mongocrud.Models;

namespace Mongocrud.DataAccessLayer
{
	public interface ICrudDL
	{
		public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest req);
	}
}
