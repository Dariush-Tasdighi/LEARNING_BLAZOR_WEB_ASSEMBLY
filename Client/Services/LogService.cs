using Dtx;

namespace Client.Services
{
	public class LogService : object
	{
		public LogService() : base()
		{
			Logs =
				new System.Collections.Generic.List<Models.Log>();
		}

		protected System.Collections.Generic.IList<Models.Log> Logs { get; }

		public void AddLog(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			message =
				message.Fix();

			var log =
				new Models.Log(message: message);

			//Logs.Add(log);
			Logs.Insert(index: 0, item: log);
		}

		public System.Collections.Generic.IList<Models.Log> GetLogs()
		{
			return Logs;
		}

		public void ClearLogs()
		{
			Logs.Clear();
		}
	}
}
