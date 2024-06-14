using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongocrud.DataAccessLayer;
using Mongocrud.Models;

namespace Mongocrud.Controllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class CrudOperationController : ControllerBase
	{

		private readonly ICrudDL _crudDL;
		
		public CrudOperationController(ICrudDL icrudDL)
		{
			_crudDL = icrudDL;
		}

		[HttpPost]
		public async Task<IActionResult>InsertRecord(InsertRecordRequest req)
		{
			InsertRecordResponse res = new InsertRecordResponse();
			try
			{
				res = await _crudDL.InsertRecord(req);
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllRecord()
		{
			GetAllRecordResponse res = new GetAllRecordResponse();
			try
			{
				res = await _crudDL.GetAllRecord();
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}

		[HttpGet]
		public async Task<IActionResult> GetRecordById(InsertRecordRequest req)
		{
			GetAllRecordResponse res = new GetAllRecordResponse();
			try
			{
				res = await _crudDL.GetAllRecord();
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}



	}
}
