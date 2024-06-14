namespace Mongocrud.DataAccessLayer
{
	public class CrudDL:ICrudDL
	{
		private readonly IConfiguration _configuration;

		public CrudDL(IConfiguration configuration)
		{
			_configuration = configuration;
		}
	}
}
