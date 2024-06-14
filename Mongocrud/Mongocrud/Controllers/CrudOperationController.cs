using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongocrud.DataAccessLayer;
using Mongocrud.Models;
using System.Xml.Linq;

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
		public async Task<IActionResult> GetRecordById([FromQuery]string Id)
		{
			GetRecordByIdResponse res = new GetRecordByIdResponse();
			try
			{
				res = await _crudDL.GetRecordById(Id);
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}

		[HttpGet]
		public async Task<IActionResult> GetRecordByName([FromQuery] string Name)
		{
			GetRecordByNameResponse res = new GetRecordByNameResponse();
			try
			{
				res = await _crudDL.GetRecordByName(Name);
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateRecordById(InsertRecordRequest req)
		{
			UpdateRecordByIdResponse res = new UpdateRecordByIdResponse();
			try
			{
				res = await _crudDL.UpdateRecordById(req);
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}



		[HttpPatch]
		public async Task<IActionResult> UpdateSalaryById(UpdateSalaryByIdRequest req)
		{
			UpdateSalaryByIdResponse res = new UpdateSalaryByIdResponse();
			try
			{
				res = await _crudDL.UpdateSalaryById(req);
			}
			catch (Exception e)
			{
				res.success = false;
				res.message = e.Message + "Some error occured";
			}

			return Ok(res);
		}


		[HttpDelete]
		public async Task<IActionResult> DeleteRecordById(string Id)
		{
			DeleteRecordByIdResponse res = new DeleteRecordByIdResponse();
			try
			{
				res = await _crudDL.DeleteRecordById(Id);
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
