using System;
using System.Collections.Generic;
using System.Xml;

namespace HarvestTimes
{
	public class TasksRepository
	{

		public IEnumerable<HarvestTask> GetTasks(String xml)
		{
			var tasks = new List<HarvestTask>();

			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.DocumentElement.SelectNodes("task");

			foreach (XmlNode node in nodes)
			{
				var taskId = Convert.ToString(node.SelectSingleNode("id").InnerText);
				var name = Convert.ToString(node.SelectSingleNode("name").InnerText);
				var billable = Convert.ToBoolean(node.SelectSingleNode("billable-by-default").InnerText);
				var newEntry = HarvestTask.CreateFromHarvestEntry(taskId, name, billable);
				tasks.Add(newEntry);
			}

			return tasks;
		}
	}
}