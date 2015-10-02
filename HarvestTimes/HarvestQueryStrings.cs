using System;

namespace HarvestTimes
{
	public class HarvestQueryStrings
	{
		private readonly HarvestCompanySettings _harvestCompanySettings;

		public string Clients()
		{
			return _harvestCompanySettings.CompanyUrl + "clients"; 	
		}

		public string Projects()
		{
			return _harvestCompanySettings.CompanyUrl + "projects";
		}

		public string People()
		{
			return _harvestCompanySettings.CompanyUrl + "people";
		}

		public string Tasks()
		{
			return _harvestCompanySettings.CompanyUrl + "tasks";
		}

		public HarvestQueryStrings(HarvestCompanySettings harvestCompanySettings)
		{
			_harvestCompanySettings = harvestCompanySettings;
		}

		public string TimeSheets(string userId, DateTime startDate, DateTime endDate)
		{
			var startDateText = startDate.ToString("yyyyMMdd");
			var endDateText = endDate.ToString("yyyyMMdd");
			var result = string.Format(_harvestCompanySettings.CompanyUrl + "people/{0}/entries?from={1}&to={2}", userId, startDateText, endDateText);
			return result;
		}

	}
}