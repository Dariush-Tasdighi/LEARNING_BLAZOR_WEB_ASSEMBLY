using Dtx;

namespace Client.Services
{
	public class LogsService : object
	{
		public LogsService() : base()
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

		public void AddLog(Models.Log log)
		{
			if (log == null)
			{
				return;
			}

			if (string.IsNullOrWhiteSpace(log.Message))
			{
				return;
			}

			log.Message =
				log.Message.Fix();

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
