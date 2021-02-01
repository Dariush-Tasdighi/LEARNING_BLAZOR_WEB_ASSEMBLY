namespace Models
{
	public class Log : object
	{
		public Log(string message) : base()
		{
			Message = message;

			Timestamp =
				System.DateTime.Now;
		}

		//public bool IsSeen { get; set; }

		public string Message { get; set; }

		//public string ClassName { get; set; }

		//public string MethodName { get; set; }

		//public string NamespaceName { get; set; }

		//public Enums.LogLevel Level { get; set; }

		public System.DateTime Timestamp { get; set; }
	}
}
