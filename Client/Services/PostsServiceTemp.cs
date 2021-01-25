using System.Net.Http.Json;

namespace Client.Services
{
	public class PostsServiceTemp : object
	{
		public PostsServiceTemp
			(System.Net.Http.HttpClient http) : base()
		{
			Http = http;

			//_http = http;
		}

		protected System.Net.Http.HttpClient Http { get; }
		//private readonly System.Net.Http.HttpClient _http;

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
