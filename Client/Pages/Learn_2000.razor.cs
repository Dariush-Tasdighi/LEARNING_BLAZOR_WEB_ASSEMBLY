namespace Client.Pages
{
	/// <summary>
	/// Note: Partial Class!
	/// Note: Do not inherit: object!
	/// </summary>
	public partial class Learn_2000
	{
		public Learn_2000() : base()
		{
			Message = "Hello, World!";
		}

		//private string _message;
		//private string _message = "Hello, World!";

		public string Message { get; set; }
		//public string Message { get; set; } = "Hello, World!";

		private void DoSomething()
		{
			Message = "Hello, World!";
		}
	}
}
