using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongocrud.DataAccessLayer;

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
		public async Task<IActionResult>InsertRecord()

	}
}
