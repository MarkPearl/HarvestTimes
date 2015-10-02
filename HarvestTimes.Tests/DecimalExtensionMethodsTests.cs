using System;
using NUnit.Framework;

namespace HarvestTimes.Tests
{
	[TestFixture]
	public class DecimalExtensionMethodsTests
	{
		[Ignore]
		[TestCase(2.5, Result = "02:30")]
		[TestCase(1.0, Result = "01:00")]
		[TestCase(1.2, Result = "01:12")]
		public string CorrectResult(Decimal input)
		{
			return input.FormatAsTime();
		}

		[TestCase(-1.0)]
		public void ThrowExceptionOutOfRange(Decimal input)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				input.FormatAsTime();
			});
		}

	}
}