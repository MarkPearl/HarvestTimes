using System;
using System.Collections.Generic;
using System.Linq;

namespace HarvestTimes
{
	public class TimeSheetEntriesToCsv
	{
		private const string FileHeader = "Date,Hours,Client,Project,Task,Person,Notes,Billable?";
		private const string Separator = @""",""";
		private const string BeginningOfLine = @"""";
		private const string EndOfLine = @"""";

		public string Generate(
			IEnumerable<HarvestTimeSheetEntry> timeSheetEntries,
			IEnumerable<HarvestProject> projects,
			IEnumerable<HarvestClient> clients,
			IEnumerable<HarvestPeople> people,
			IEnumerable<HarvestTask> tasks)
		{

			var result = new List<string>();
			result.Add(FileHeader);
			result.AddRange(timeSheetEntries.Select(entry =>
			{
				return GenerateLine(entry, projects, clients, people, tasks);
			}));
			return String.Join(Environment.NewLine, result);
		}

		private string GenerateLine(
			HarvestTimeSheetEntry entry,
			IEnumerable<HarvestProject> projects,
			IEnumerable<HarvestClient> clients,
			IEnumerable<HarvestPeople> people,
			IEnumerable<HarvestTask> tasks)
		{
			var project = projects.Single(p => p.ProjectId == entry.ProjectId);
			var client = clients.Single(c => c.ClientId == project.ClientId);
			var person = people.Single(p => p.PersonId == entry.UserId);
			var task = tasks.Single(t => t.TaskId == entry.TaskId);

			var result = new List<string>();
			result.Add(entry.DateOfEntry.ToString("dd-MM-yyyy hh:mm:ss"));
			result.Add(entry.Hours.FormatAsTime());
			result.Add(client.Address);
			result.Add(project.Notes);
			result.Add(task.Name);
			result.Add(person.FullName);
			result.Add(string.Empty);
			result.Add(task.IsBillable ? "true" : "false");
			return BeginningOfLine + string.Join(Separator, result) + EndOfLine;
		}

	}
}