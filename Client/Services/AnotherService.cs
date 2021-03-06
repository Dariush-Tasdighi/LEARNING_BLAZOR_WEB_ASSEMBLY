﻿namespace Client.Services
{
	public class AnotherService : object
	{
		public AnotherService
			(ApplicationSettingsService applicationSettingsService) : base()
		{
			ApplicationSettingsService = applicationSettingsService;
		}

		protected ApplicationSettingsService ApplicationSettingsService { get; }

		public void DoSomething()
		{
			string baseUrl =
				ApplicationSettingsService.BaseUrl;

			string token =
				ApplicationSettingsService.Token;
		}
	}
}
