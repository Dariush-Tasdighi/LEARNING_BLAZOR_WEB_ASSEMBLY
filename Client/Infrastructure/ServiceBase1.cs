﻿using System.Net.Http.Json;

namespace Infrastructure
{
	public abstract class ServiceBase1 : object
	{
		public ServiceBase1(System.Net.Http.HttpClient http) : base()
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
			System.Threading.Tasks.Task<TResponse>
			GetAsync<TResponse>(string url, string query = null)
		{
			System.Net.Http.HttpResponseMessage response = null;

			try
			{
				string requestUri =
					$"{ BaseUrl }/{ url }";

				if (string.IsNullOrWhiteSpace(query) == false)
				{
					requestUri =
						$"{ requestUri }?{ query }";
				}

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
						// ReadFromJsonAsync -> Extension Method -> using System.Net.Http.Json;
						TResponse result =
							await
							response.Content.ReadFromJsonAsync<TResponse>();

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

			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}

			finally
			{
				response.Dispose();
				//response = null;
			}

			return default;
		}
	}
}
