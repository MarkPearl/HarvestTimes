using System;
using System.Collections.Generic;
using System.Xml;

namespace HarvestTimes
{
	public class PeopleRepository
	{

		public IEnumerable<HarvestPeople> GetPeople(String xml)
		{
			var people = new List<HarvestPeople>();

			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.DocumentElement.SelectNodes("user");

			foreach (XmlNode node in nodes)
			{
				var personId = Convert.ToString(node.SelectSingleNode("id").InnerText);
				var firstName = Convert.ToString(node.SelectSingleNode("first-name").InnerText);
				var lastName = Convert.ToString(node.SelectSingleNode("last-name").InnerText);
				var newEntry = HarvestPeople.CreateFromHarvestEntry(personId, firstName, lastName);
				people.Add(newEntry);
			}

			return people;
		}
	}
}