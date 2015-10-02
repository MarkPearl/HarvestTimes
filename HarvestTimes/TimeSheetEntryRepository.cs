using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace HarvestTimes
{
	public class TimeSheetEntryRepository
	{
		private const string NumberDecimalSeparator = ".";

		public IEnumerable<HarvestTimeSheetEntry> GetEntries(String xml)
		{
			var timeSheetEntries = new List<HarvestTimeSheetEntry>();

			var doc = new XmlDocument();
			doc.LoadXml(xml);
			var nodes = doc.DocumentElement.SelectNodes("day-entry");

			foreach (XmlNode node in nodes)
			{
				var dateOfEntry = Convert.ToDateTime(node.SelectSingleNode("spent-at").InnerText);
				var hours = Convert.ToDecimal(node.SelectSingleNode("hours").InnerText, new NumberFormatInfo() { NumberDecimalSeparator = NumberDecimalSeparator });
				var userId = Convert.ToString(node.SelectSingleNode("user-id").InnerText);
				var projectId = Convert.ToString(node.SelectSingleNode("project-id").InnerText);
				var taskId = Convert.ToString(node.SelectSingleNode("task-id").InnerText);
				var notes = Convert.ToString(node.SelectSingleNode("notes").InnerText);
				var billable = Convert.ToBoolean(node.SelectSingleNode("is-billed").InnerText);
				var newEntry = HarvestTimeSheetEntry.CreateFromHarvestEntry(dateOfEntry, hours, userId, projectId, taskId, notes, billable);

				timeSheetEntries.Add(newEntry);
			}

			return timeSheetEntries;
		}
	}
}