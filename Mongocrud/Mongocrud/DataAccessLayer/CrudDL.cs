using Microsoft.AspNetCore.Http.HttpResults;
using Mongocrud.Models;
using MongoDB.Bson;
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

		public async Task<GetRecordByIdResponse> GetRecordById(string Id)
		{
			GetRecordByIdResponse res = new GetRecordByIdResponse();
			res.success = true;
			res.message = "Success added!";

			try
			{
				res.data = await _mongoCollection.Find(x => (x.Id == Id)).FirstOrDefaultAsync();

				if (res.data==null)
				{
					res.message = "Invalid Id, please enter valid ID";
				}
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return res;
		}

		
		public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
		{
			GetRecordByNameResponse res = new GetRecordByNameResponse();
			res.success = true;
			res.message = "Success added!";

			try
			{
				res.data = await _mongoCollection.Find(x => (x.Firstname == Name)).ToListAsync<InsertRecordRequest>();

				if (res.data == null)
				{
					res.message = "Invalid Id, please enter valid ID";
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

		public async Task<UpdateRecordByIdResponse> UpdateRecordById(InsertRecordRequest req)
		{
			UpdateRecordByIdResponse res = new UpdateRecordByIdResponse();
			res.success = true;
			res.message = "Success added!";
			try
			{
				GetRecordByIdResponse res1 = await GetRecordById(req.Id);
				req.updatedAt = DateTime.Now.ToString();	
				req.createdAt=res1.data.createdAt;
				var result = await _mongoCollection.ReplaceOneAsync(x => x.Id == req.Id, req);

				if (!result.IsAcknowledged)
				{
					res.success = false;
					res.message = "Not updated";
				}

			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";

			}

			return res;
		}

		public async Task<DeleteRecordByIdResponse> DeleteRecordById(string Id)
		{
			DeleteRecordByIdResponse res = new DeleteRecordByIdResponse();
			res.success = true;
			res.message = "Success added!";

			try
			{
				await _mongoCollection.DeleteOneAsync(x => x.Id == Id);

			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return res;
		}

		public async Task<UpdateSalaryByIdResponse> UpdateSalaryById(UpdateSalaryByIdRequest req)
		{
			UpdateSalaryByIdResponse res = new UpdateSalaryByIdResponse();
			res.success = true;
			res.message = "Success added!";
			try
			{
				var Filter=new BsonDocument().Add("salary",req.salary).Add("updatedAt",DateTime.Now.ToString());
				var updatedAt=new BsonDocument("$set",Filter);
				var result = await _mongoCollection.UpdateOneAsync(x=>x.Id==req.Id,updatedAt);

				if (!result.IsAcknowledged)
				{
					res.success = false;
					res.message = "Not updated";
				}

			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";

			}

			return res;
		}

		public async Task<UpdateSalaryByIdResponse> DeleteAllRecord()
		{

			UpdateSalaryByIdResponse res = new UpdateSalaryByIdResponse();
			res.success = true;
			res.message = "Success added!";

			try
			{
				await _mongoCollection.DeleteManyAsync(x => true);

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
