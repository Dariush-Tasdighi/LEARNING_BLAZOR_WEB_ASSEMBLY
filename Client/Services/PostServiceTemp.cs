using System.Net.Http.Json;

namespace Client.Services
{
	public class PostServiceTemp : object
	{
		public PostServiceTemp
			(System.Net.Http.HttpClient http) : base()
		{
			Http = http;
		}

		//protected private System.Net.Http.HttpClient _http { get; }
		//protected System.Net.Http.HttpClient Http { get; set; }
		protected System.Net.Http.HttpClient Http { get; }

		public
			async
			System.Threading.Tasks.Task
			<System.Collections.Generic.IList<Models.Post>>
			GetAsync()
		{
			string requestUri =
				"https://jsonplaceholder.typicode.com/posts";

			// GetFromJsonAsync -> Extension Method -> using System.Net.Http.Json;
			var result =
				await
				Http.GetFromJsonAsync
				<System.Collections.Generic.IList<Models.Post>>
				(requestUri: requestUri);

			return result;
		}
	}
}
