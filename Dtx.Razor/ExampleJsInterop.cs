using Microsoft.JSInterop;

namespace Dtx.Razor
{
	// This class provides an example of how JavaScript functionality can be wrapped
	// in a .NET class for easy consumption. The associated JavaScript module is
	// loaded on demand when first needed.
	//
	// This class can be registered as scoped DI service and then injected into Blazor
	// components for use.

	public class ExampleJsInterop : object, System.IAsyncDisposable
	{
		public ExampleJsInterop() : base()
		{
		}

		private readonly
			System.Lazy<System.Threading.Tasks.Task<Microsoft.JSInterop.IJSObjectReference>> moduleTask;

		public ExampleJsInterop(Microsoft.JSInterop.IJSRuntime jsRuntime)
		{
			moduleTask =
				new(() => jsRuntime.InvokeAsync<Microsoft.JSInterop.IJSObjectReference>
				("import", "./_content/Dtx.Razor/exampleJsInterop.js").AsTask());
		}

		public async System.Threading.Tasks.ValueTask<string> Prompt(string message)
		{
			var module =
				await moduleTask.Value;

			return await module.InvokeAsync<string>("showPrompt", message);
		}

		public async System.Threading.Tasks.ValueTask DisposeAsync()
		{
			if (moduleTask.IsValueCreated)
			{
				var module =
					await moduleTask.Value;

				await module.DisposeAsync();
			}
		}
	}
}
