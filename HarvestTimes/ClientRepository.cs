using System;
using System.Collections.Generic;
using System.Xml;

namespace HarvestTimes
{
	public class ClientRepository
	{

		public IEnumerable<HarvestClient> GetClients(String xml)
		{
			var clients = new List<HarvestClient>();

			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.DocumentElement.SelectNodes("client");

			foreach (XmlNode node in nodes)
			{
				var name = Convert.ToString(node.SelectSingleNode("name").InnerText);
				var clientId = Convert.ToString(node.SelectSingleNode("id").InnerText);
				var address = Convert.ToString(node.SelectSingleNode("details").InnerText);
				var newEntry = HarvestClient.CreateFromHarvestEntry(clientId, name, address);
				clients.Add(newEntry);
			}

			return clients;
		}
	}
}