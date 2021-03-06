﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webrew.Common.Interfaces;
using Webrew.Managers;
using Webrew.Managers.Interfaces;

namespace webrew_dotnet.Helpers.Startup
{
	public static class ConfigureManagers
	{
		public static IServiceCollection AddManagers(this IServiceCollection services)
		{
			services.AddSingleton<IHomeManager, HomeManager>();
			services.AddSingleton<IBeerManager, BeerManager>();
			services.AddSingleton<IReviewManager, ReviewManager>();
			services.AddSingleton<ILoginManager, LoginManager>();
			services.AddSingleton<IAccountManagement, AccountManagement>();
			return services;
		}
	}
}
