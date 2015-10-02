using System;
using System.Runtime.InteropServices;

namespace HarvestTimes
{
	public static class Program
	{
		public static void Main()
		{
			var harvestUserSettings = new HarvestUserSettings();
			var harvestClientsQuery = new HarvestClientsQuery(harvestUserSettings);
			var startDate = new DateTime(2015,9,1);
			var endDate = new DateTime(2015,9,30);

			var tsRepository = new TimeSheetEntryRepository();
			var harvestQueryStrings = new HarvestQueryStrings(new HarvestCompanySettings());
			var tsSource = harvestClientsQuery.GetData(harvestQueryStrings.TimeSheets(harvestUserSettings.UserId, startDate, endDate));
			var tsEntries = tsRepository.GetEntries(tsSource);

			var projectRepository = new ProjectRepository();
			var projectSource = harvestClientsQuery.GetData(harvestQueryStrings.Projects());
			var projectEntries = projectRepository.GetProjects(projectSource);

			var clientRepository = new ClientRepository();
			var clientSource = harvestClientsQuery.GetData(harvestQueryStrings.Clients());
			var clientEntries = clientRepository.GetClients(clientSource);

			var peopleRepository = new PeopleRepository();
			var peopleSource = harvestClientsQuery.GetData(harvestQueryStrings.People());
			var peopleEntries = peopleRepository.GetPeople(peopleSource);

			var tasksRepository = new TasksRepository();
			var tasksSource = harvestClientsQuery.GetData(harvestQueryStrings.Tasks());
			var tasks = tasksRepository.GetTasks(tasksSource);

			var cashboardAppExporter = CashboardAppExporterCommand.Create(tsEntries, projectEntries, clientEntries, peopleEntries, tasks);

			cashboardAppExporter.Execute();
			
		}
		 
	}
}