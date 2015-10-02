namespace HarvestTimes
{
	public class HarvestClient
	{
		public string ClientId { get; private set; }
		public string Name { get; private set; }
		public string Address { get; private set; }

		private HarvestClient()
		{
			
		}

		public static HarvestClient CreateFromHarvestEntry(string clientId, string name, string address)
		{
			var result = new HarvestClient();
			result.ClientId = clientId;
			result.Name = name;
			result.Address = address;
			return result;
		}
	}
}