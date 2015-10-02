using System;
using System.Collections.Generic;
using System.Xml;

namespace HarvestTimes
{
	public class ProjectRepository
	{

		public IEnumerable<HarvestProject> GetProjects(String xml)
		{
			var projects = new List<HarvestProject>();

			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.DocumentElement.SelectNodes("project");

			foreach (XmlNode node in nodes)
			{
				var name = Convert.ToString(node.SelectSingleNode("name").InnerText);
				var projectId = Convert.ToString(node.SelectSingleNode("id").InnerText);
				var clientId = Convert.ToString(node.SelectSingleNode("client-id").InnerText);
				var code = Convert.ToString(node.SelectSingleNode("code").InnerText);
				var notes = Convert.ToString(node.SelectSingleNode("notes").InnerText);
				var newEntry = HarvestProject.CreateFromHarvestEntry(projectId, name, clientId, code, notes);
				projects.Add(newEntry);
			}

			return projects;
		}
	}
}