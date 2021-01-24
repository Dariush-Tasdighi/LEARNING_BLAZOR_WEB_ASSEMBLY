using System.Net.Http.Json;

namespace Infrastructure
{
	public abstract class BaseService : object
	{
		public BaseService(System.Net.Http.HttpClient http) : base()
		{
			Http = http;

			//JsonOptions =
			//	new System.Text.Json.JsonSerializerOptions
			//	{
			//		PropertyNameCaseInsensitive = true,
			//	};

			//Http.DefaultRequestHeaders
		}

		protected string BaseUrl { get; set; }

		protected System.Net.Http.HttpClient Http { get; }

		//protected System.Text.Json.JsonSerializerOptions JsonOptions { get; set; }

		protected virtual
			async
			System.Threading.Tasks.Task<TTesponse>
			GetAsync<TTesponse>(string query)
		{
			System.Net.Http.HttpResponseMessage response = null;

			try
			{
				string requestUri =
					$"{ BaseUrl }/{ query }";

				//string requestUri =
				//	"https://jsonplaceholder.typicode.com/posts";

				response =
					await
					Http.GetAsync
					(requestUri: requestUri)
					;

				response.EnsureSuccessStatusCode();

				if (response.IsSuccessStatusCode)
				{
					try
					{
						TTesponse result =
							await
							response.Content.ReadFromJsonAsync<TTesponse>();

						return result;
					}
					// When content type is not valid
					catch (System.NotSupportedException)
					{
						System.Console.WriteLine("The content type is not supported.");
					}
					// Invalid JSON
					catch (System.Text.Json.JsonException)
					{
						System.Console.WriteLine("Invalid JSON.");
					}
				}
			}
			catch (System.Net.Http.HttpRequestException ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				response.Dispose();
			}

			return default;
		}

		//protected virtual
		//	async
		//	System.Threading.Tasks.Task<O>
		//	PostAsync<I, O>(I viewModel)
		//{
		//	System.Net.Http.HttpResponseMessage response = null;

		//	try
		//	{
		//		response =
		//			await Http.PostAsJsonAsync
		//			(requestUri: RequestUri, value: viewModel);

		//		response.EnsureSuccessStatusCode();

		//		if (response.IsSuccessStatusCode)
		//		{
		//			try
		//			{
		//				//System.Text.Json.JsonSerializerOptions jsonSerializerOptions =
		//				//	new System.Text.Json.JsonSerializerOptions
		//				//	{
		//				//		MaxDepth = 5,
		//				//	};

		//				//O result =
		//				//	await response.Content.ReadFromJsonAsync<O>(options: jsonSerializerOptions);



		//				// New Solution
		//				O result =
		//					await response.Content.ReadFromJsonAsync<O>();

		//				return result;
		//				// /New Solution

		//				// Old Solution
		//				//string data =
		//				//	await response.Content.ReadAsStringAsync();

		//				//O result =
		//				//	System.Text.Json.JsonSerializer.Deserialize<O>(data);
		//				// /Old Solution
		//			}
		//			// When content type is not valid
		//			catch (System.NotSupportedException)
		//			{
		//				System.Console.WriteLine("The content type is not supported.");
		//			}
		//			// Invalid JSON
		//			catch (System.Text.Json.JsonException)
		//			{
		//				System.Console.WriteLine("Invalid JSON.");
		//			}
		//		}
		//	}
		//	catch (System.Net.Http.HttpRequestException ex)
		//	{
		//		System.Console.WriteLine(ex.Message);
		//	}
		//	finally
		//	{
		//		response.Dispose();
		//		//response = null;
		//	}

		//	return default;
		//}

		//protected virtual
		//	async
		//	System.Threading.Tasks.Task<O>
		//	PutAsync<I, O>(I viewModel)
		//{
		//	System.Net.Http.HttpResponseMessage response = null;

		//	try
		//	{
		//		response =
		//			await Http.PutAsJsonAsync
		//			(requestUri: RequestUri, value: viewModel);

		//		response.EnsureSuccessStatusCode();

		//		if (response.IsSuccessStatusCode)
		//		{
		//			try
		//			{
		//				O result =
		//					await response.Content.ReadFromJsonAsync<O>();

		//				return result;
		//			}
		//			// When content type is not valid
		//			catch (System.NotSupportedException)
		//			{
		//				System.Console.WriteLine("The content type is not supported.");
		//			}
		//			// Invalid JSON
		//			catch (System.Text.Json.JsonException)
		//			{
		//				System.Console.WriteLine("Invalid JSON.");
		//			}
		//		}
		//	}
		//	catch (System.Net.Http.HttpRequestException ex)
		//	{
		//		System.Console.WriteLine(ex.Message);
		//	}
		//	finally
		//	{
		//		response.Dispose();
		//	}

		//	return default;
		//}

		//protected virtual
		//	async
		//	System.Threading.Tasks.Task<O>
		//	DeleteAsync<O>()
		//{
		//	System.Net.Http.HttpResponseMessage response = null;

		//	try
		//	{
		//		response =
		//			await Http.DeleteAsync(requestUri: RequestUri);

		//		response.EnsureSuccessStatusCode();

		//		if (response.IsSuccessStatusCode)
		//		{
		//			try
		//			{
		//				O result =
		//					await response.Content.ReadFromJsonAsync<O>();

		//				return result;
		//			}
		//			// When content type is not valid
		//			catch (System.NotSupportedException)
		//			{
		//				System.Console.WriteLine("The content type is not supported.");
		//			}
		//			// Invalid JSON
		//			catch (System.Text.Json.JsonException)
		//			{
		//				System.Console.WriteLine("Invalid JSON.");
		//			}
		//		}
		//	}
		//	catch (System.Net.Http.HttpRequestException ex)
		//	{
		//		System.Console.WriteLine(ex.Message);
		//	}
		//	finally
		//	{
		//		response.Dispose();
		//	}

		//	return default;
		//}
	}
}
