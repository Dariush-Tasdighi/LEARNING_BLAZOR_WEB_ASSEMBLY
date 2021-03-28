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

			//builder.Services.AddScoped(System.Net.Http.HttpClient);

			//builder.Services.AddScoped<System.Net.Http.HttpClient>();

			builder.Services.AddSingleton
				(current => new System.Net.Http.HttpClient
				{
					BaseAddress =
						new System.Uri(builder.HostEnvironment.BaseAddress),
				});

			//builder.Services.AddScoped<Services.PostsServiceTemp1>();
			//builder.Services.AddTransient<Services.PostsServiceTemp1>();
			builder.Services.AddSingleton<Services.PostsServiceTemp1>();

			builder.Services.AddSingleton<Services.PostsServiceTemp2>();
			builder.Services.AddSingleton<Services.PostsServiceTemp3>();

			// نکته مهم: دستور فوق کار نمی‌کند
			// در صورتی که
			// Http
			// به صورت
			// AddScoped
			// ثبت شده باشد

			builder.Services.AddSingleton<Services.LogsService>();
			builder.Services.AddSingleton<Services.PostsService>();

			builder.Services.AddSingleton<Services.ApplicationSettingsService>();

			await builder.Build().RunAsync();
		}
	}
}
