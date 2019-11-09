using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webrew_dotnet.Helpers.Startup
{
	public class ConfigurationOptions
	{
		public IConfiguration Configuration { get; private set; }

		public IConfiguration SetConfiguration(IConfiguration configuration)
		{
			Configuration = configuration;
			return Configuration;
		}
	}
}
