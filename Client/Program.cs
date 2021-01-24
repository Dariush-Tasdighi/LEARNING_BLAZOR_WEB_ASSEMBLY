using Microsoft.Extensions.DependencyInjection;

namespace Client
{
	public class Program : object
	{
		public Program() : base()
		{
		}

		public static async System.Threading.Tasks.Task Main(string[] args)
		{
			var builder =
				Microsoft.AspNetCore.Components.WebAssembly.Hosting
				.WebAssemblyHostBuilder.CreateDefault(args);

			builder.RootComponents.Add<App>("#app");

			//builder.Services.AddScoped<System.Net.Http.HttpClient>();

			//builder.Services.AddScoped(System.Net.Http.HttpClient);

			builder.Services.AddSingleton
				(current => new System.Net.Http.HttpClient
				{
					BaseAddress =
						new System.Uri(builder.HostEnvironment.BaseAddress),
				});

			//builder.Services.AddScoped<Services.PostServiceTemp>();
			//builder.Services.AddTransient<Services.PostServiceTemp>();
			builder.Services.AddSingleton<Services.PostServiceTemp>();

			// نکته مهم: دستور فوق کار نمی‌کند
			// در صورتی که
			// Http
			// به صورت
			// AddScoped
			// ثبت شده باشد

			builder.Services.AddSingleton<Services.LogService>();
			builder.Services.AddSingleton<Services.PostService>();

			await builder.Build().RunAsync();
		}
	}
}
