using Mongocrud.Models;

namespace Mongocrud.DataAccessLayer
{
	public class CrudDL : ICrudDL
	{
		private readonly IConfiguration _configuration;

		public CrudDL(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest req)
		{
			InsertRecordResponse res = new InsertRecordResponse();
			try
			{

			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
				
			}

			return res;
		}

		
	}
}
