using System;

namespace HarvestTimes
{
	public class HarvestProject
	{
		public string ProjectId { get; private set; }
		public string ClientId { get; private set; }
		public string Name { get; private set; }
		public string Code { get; private set; }
		public string Notes { get; private set; }

		private HarvestProject()
		{
			
		}

		public static HarvestProject CreateFromHarvestEntry(string projectId, string name, string clientId, string code, string notes)
		{
			var result = new HarvestProject();
			result.ProjectId = projectId;
			result.ClientId = clientId;
			result.Name = name;
			result.Code = code;
			result.Notes = notes;
			return result;
		}
	}
}