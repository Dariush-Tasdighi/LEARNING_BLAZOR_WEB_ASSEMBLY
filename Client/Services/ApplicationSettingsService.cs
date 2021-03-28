namespace Client.Services
{
	/// <summary>
	/// In Memory Database!
	/// Instead of Cookie or LocalStorage
	/// </summary>
	public class ApplicationSettingsService : object
	{
		public ApplicationSettingsService() : base()
		{
		}

		public bool IsAuthenticated
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Token))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public string Token { get; set; }

		public string FullName { get; set; }

		public string Username { get; set; }
	}
}
