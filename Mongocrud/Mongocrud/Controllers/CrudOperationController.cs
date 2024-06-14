using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongocrud.DataAccessLayer;
using Mongocrud.Models;

namespace Mongocrud.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CrudOperationController : ControllerBase
	{

		private readonly ICrudDL _ICrudDL;
		
		public CrudOperationController(ICrudDL icrudDL)
		{
			_ICrudDL = icrudDL;
		}

		[HttpPost]
		public async Task<IActionResult>InsertRecord(InsertRecordRequest req)
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

			return Ok(res);
		}



	}
}
