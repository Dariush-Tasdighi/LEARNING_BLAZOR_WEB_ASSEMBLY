namespace Client.Services
{
	public class PostsServiceTemp1 : object
	{
		public PostsServiceTemp1() : base()
		{
		}

		public
			async
			System.Threading.Tasks.Task
			<System.Collections.Generic.IList<Models.Post>>
			GetAsync()
		{
			System.Collections.Generic.List<Models.Post> result = null;

			await System.Threading.Tasks.Task.Run(() =>
			{
				result =
					new System.Collections.Generic.List<Models.Post>();

				for (int index = 1; index <= 10; index++)
				{
					var post =
						new Models.Post
						{
							Id = index,
							Body = $"Body { index }",
							Title = $"Title { index }",
						};

					result.Add(post);
				}
			});

			return result;
		}
	}
}
