using System.Collections.Generic;
using System.IO;

namespace HarvestTimes
{
	public class CashboardAppExporterCommand
	{
		private readonly TimeSheetEntriesToCsv _timeSheetEntriesToCsv;
		private readonly IEnumerable<HarvestTimeSheetEntry> _timeSheetEntries;
		private readonly IEnumerable<HarvestProject> _projects;
		private readonly IEnumerable<HarvestClient> _clients;
		private readonly IEnumerable<HarvestPeople> _people;
		private readonly IEnumerable<HarvestTask> _tasks;

		private CashboardAppExporterCommand(
			IEnumerable<HarvestTimeSheetEntry> timeSheetEntries, 
			IEnumerable<HarvestProject> projects, 
			IEnumerable<HarvestClient> clients, 
			IEnumerable<HarvestPeople> people, 
			IEnumerable<HarvestTask> tasks)
		{
			_timeSheetEntriesToCsv = new TimeSheetEntriesToCsv();
			_timeSheetEntries = timeSheetEntries;
			_projects = projects;
			_clients = clients;
			_people = people;
			_tasks = tasks;
		}

		public void Execute()
		{
			const string directory = @"d:\temp\";
			const string fileName = "export.txt";
			string path = Path.Combine(directory, fileName);

			var content = _timeSheetEntriesToCsv.Generate(_timeSheetEntries, _projects, _clients, _people, _tasks);
			Directory.CreateDirectory(directory);
			File.WriteAllText(path, content);
		}

		public static CashboardAppExporterCommand Create(
			IEnumerable<HarvestTimeSheetEntry> timeSheetEntries, 
			IEnumerable<HarvestProject> projects, 
			IEnumerable<HarvestClient> clients, 
			IEnumerable<HarvestPeople> people, 
			IEnumerable<HarvestTask> tasks)
		{
			var result = new CashboardAppExporterCommand(timeSheetEntries, projects, clients, people, tasks);
			return result;
		}
	}
}