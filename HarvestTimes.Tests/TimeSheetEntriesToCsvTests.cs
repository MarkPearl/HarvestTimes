using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace HarvestTimes.Tests
{
	[TestFixture]
	public class TimeSheetEntriesToCsvTests
	{
		[Test]
		[UseReporter(typeof(DiffReporter))]
		public void GenerateCorrectExport()
		{
			var sut = new TimeSheetEntriesToCsv();
			var data = new List<HarvestTimeSheetEntry>()
			{
				HarvestTimeSheetEntry.CreateFromHarvestEntry(
					new DateTime(2015,01,19,16,52,27),
					10M,
					"123",
					"456",
					"789",
					"Note",
					true
				)
			};

			var result = sut.Generate(data, null, null, null, null);
			Approvals.Verify(result);
		}

	}
}