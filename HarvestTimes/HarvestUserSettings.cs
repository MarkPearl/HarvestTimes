using System.Configuration;

namespace HarvestTimes
{
	public class HarvestUserSettings
	{
		public string Username
		{
			get { return ConfigurationManager.AppSettings["HarvestUserName"]; }
		}

		public string Password
		{
			get { return ConfigurationManager.AppSettings["HarvestPassword"]; }
		}

		public string UserId
		{
			get { return ConfigurationManager.AppSettings["HarvestUserId"]; }
		}
	}

	public class HarvestCompanySettings
	{
		public string CompanyUrl
		{
			get { return ConfigurationManager.AppSettings["HarvestCompanyUrl"]; }
		}
		
	}
}