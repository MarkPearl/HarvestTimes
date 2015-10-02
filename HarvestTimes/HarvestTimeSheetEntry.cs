using System;

namespace HarvestTimes
{
	public class HarvestTimeSheetEntry
	{
		public DateTime DateOfEntry { get; private set; }
		public decimal Hours { get; private set; }
		public string UserId { get; private set; }
		public string ProjectId { get; private set; }
		public string TaskId { get; private set; }
		public string Notes { get; private set; }
		public bool Billable { get; private set; }


		public static HarvestTimeSheetEntry CreateFromHarvestEntry(DateTime dateOfEntry, decimal hours, string userId, string projectId, string taskId, string notes, bool billable)
		{
			var result = new HarvestTimeSheetEntry();
			result.UserId = userId;
			result.ProjectId = projectId;
			result.TaskId = taskId;
			result.Billable = billable;
			result.Notes = notes;
			result.DateOfEntry = dateOfEntry;
			result.Hours = hours;
			return result;
		}
	}
}