namespace HarvestTimes
{
	public class HarvestTask
	{
		public string TaskId { get; private set; }
		public string Name { get; private set; }
		public bool IsBillable { get; private set; }

		private HarvestTask()
		{
			
		}

		public static HarvestTask CreateFromHarvestEntry(string taskId, string name, bool isBillable)
		{
			var result = new HarvestTask();
			result.TaskId = taskId;
			result.Name = name;
			result.IsBillable = isBillable;
			return result;
		}
	}
}