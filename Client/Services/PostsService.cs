namespace Client.Services
{
	public class PostsService : Infrastructure.ServiceBase
	{
		public PostsService
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
			string url = "posts";

			var result =
				await
				GetAsync
				<System.Collections.Generic.IList<Models.Post>>
				(url: url);

			return result;
		}
	}
}
