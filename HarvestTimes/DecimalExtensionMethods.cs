using System;

namespace HarvestTimes
{
	public static class DecimalExtensionMethods
	{
		public static string FormatAsTime(this decimal value)
		{
			var hours = Math.Truncate(value);
			var decimalPart = value - Math.Truncate(value);
			var minutes = 60 * decimalPart;

			EnsureHoursIsWithinRange(hours);

			return string.Format("{0:00}:{1:00}", hours, minutes);
		}

		private static void EnsureHoursIsWithinRange(decimal hours)
		{
			if (hours < 0) throw new ArgumentOutOfRangeException("Hours cannot be negative");
		}
	}
}