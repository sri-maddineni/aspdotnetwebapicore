using Microsoft.AspNetCore.Http.HttpResults;
using Mongocrud.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace Mongocrud.DataAccessLayer
{
	public class CrudDL : ICrudDL
	{
		private readonly IConfiguration _configuration;
		private readonly MongoClient _mongoclient;
		private readonly IMongoCollection<InsertRecordRequest> _mongoCollection;

		public CrudDL(IConfiguration configuration)
		{
			_configuration = configuration;
			_mongoclient=new MongoClient(_configuration["Database:ConnectionString"]);

			var _MongoDatabase = _mongoclient.GetDatabase(_configuration["Database:DatabaseName"]);
			_mongoCollection = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration["Database:CollectionName"]);

			
			
		}

		public async Task<GetAllRecordResponse> GetAllRecord()
		{
			GetAllRecordResponse res = new GetAllRecordResponse();
			res.success = true;
			res.message = "Success added!";

			try
			{
				res.data = new List<InsertRecordRequest>();
				res.data=await _mongoCollection.Find(x=>true).ToListAsync();

				if (res.data.Count == 0)
				{
					res.message = "No records found";
				}
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return res;
		}

		public async Task<InsertRecordResponse> InsertRecord(InsertRecordRequest req)
		{
			InsertRecordResponse res = new InsertRecordResponse();
			res.success = true;
			res.message = "Success added!";
			try
			{
				req.createdAt = DateTime.Now.ToString();
				


				await _mongoCollection.InsertOneAsync(req);
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
