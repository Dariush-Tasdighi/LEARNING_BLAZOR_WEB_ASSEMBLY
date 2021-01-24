namespace Client.Services
{
	public class PostService : Infrastructure.BaseService
	{
		public PostService
			(System.Net.Http.HttpClient http) : base(http: http)
		{
			BaseUrl =
				"https://jsonplaceholder.typicode.com";
		}

		public
			async
			System.Threading.Tasks.Task
			<System.Collections.Generic.IList<Models.Post>>
			GetAsync()
		{
			string query = "posts";

			var result =
				await
				GetAsync
				<System.Collections.Generic.IList<Models.Post>>
				(query: query);

			return result;
		}
	}
}
