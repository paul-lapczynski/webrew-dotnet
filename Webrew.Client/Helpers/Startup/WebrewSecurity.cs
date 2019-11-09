using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webrew.Common.Interfaces;
using Webrew.Common.Models;

namespace webrew_dotnet.Helpers.Startup
{
	public static class WebrewSecurity
	{
		public static IServiceCollection AddSecuritySettingsSingleton(this IServiceCollection services, Action<ConfigurationOptions> setupAction)
		{
			var options = new ConfigurationOptions();
			setupAction(options);

			services
				.Configure<SecuritySettings>(options.Configuration.GetSection(nameof(SecuritySettings)))
				.AddSingleton<ISecuritySettings>(sp => sp.GetRequiredService<IOptions<SecuritySettings>>().Value);

			return services;
		}
	}
}
