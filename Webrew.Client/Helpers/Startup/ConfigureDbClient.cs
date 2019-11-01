using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Webrew.Data;
using Webrew.Data.Collections;
using Webrew.Data.Interfaces;
using Webrew.Data.Repositories;

namespace webrew_dotnet.Helpers.Startup
{
	public static class ConfigureDbClient
	{
		public static IServiceCollection AddDbClient(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DbClientOptions>(configuration.GetSection(nameof(DbClientOptions)));
			services.AddSingleton<IDbClientOptions>(sp => sp.GetRequiredService<IOptions<DbClientOptions>>().Value);
			services.AddSingleton<IDbClient, DbClient>();
			services.AddSingleton<ICoffeeCollection, CoffeeCollection>();
			services.AddSingleton<ICoffeeRepository, CoffeeRepository>();
			return services;
		}
	}
}
