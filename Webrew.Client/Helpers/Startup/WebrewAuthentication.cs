using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace webrew_dotnet.Helpers.Startup
{
	public static class WebrewAuthentication
	{
		public static IServiceCollection AddWebrewAuthentication(this IServiceCollection services, Action<ConfigurationOptions> setupAction)
		{
			var options = new ConfigurationOptions();
			setupAction(options);

			var settings = options.Configuration.GetSection(nameof(SecuritySettings)).Get<SecuritySettings>();
			var key = Encoding.UTF8.GetBytes(settings.JwtSecret);

			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.SaveToken = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(key),
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true
					};
				});

			return services;
		}
	}
}
