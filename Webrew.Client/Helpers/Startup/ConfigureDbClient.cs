using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using Webrew.Data;
using Webrew.Data.Collections;
using Webrew.Data.Interfaces;
using Webrew.Data.Repositories;

namespace webrew_dotnet.Helpers.Startup
{
	public static class ConfigureDbClient
	{
		public static IServiceCollection AddDbClient(this IServiceCollection services, Action<AddDbClientOptions> setupAction)
		{
			var options = new AddDbClientOptions();
			setupAction(options);

			services.Configure<DbClientOptions>(options.Configuration.GetSection(nameof(DbClientOptions)));
			services.AddSingleton<IDbClientOptions>(sp => sp.GetRequiredService<IOptions<DbClientOptions>>().Value);
			services.AddSingleton<IDbClient, DbClient>();
			services.AddSingleton<IBeerCollection, BeerCollection>();
			services.AddSingleton<IReviewCollection, ReviewCollection>();
			services.AddSingleton<IBeerRepository, BeerRepository>();
			services.AddSingleton<IReviewRepository, ReviewRepository>();
			return services;
		}
	}


}
