namespace HarvestTimes
{
	public class HarvestPeople
	{
		public string PersonId { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; set; }

		public string FullName
		{
			get { return string.Format("{0} {1}", FirstName, LastName); }
		}

		private HarvestPeople()
		{
			
		}

		public static HarvestPeople CreateFromHarvestEntry(string personId, string firstName, string lastName)
		{
			var result = new HarvestPeople();
			result.PersonId = personId;
			result.FirstName = firstName;
			result.LastName = lastName;
			return result;
		}

	}
}