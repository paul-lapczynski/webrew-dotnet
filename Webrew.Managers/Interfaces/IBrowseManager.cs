using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Common.Models;

namespace Webrew.Managers.Interfaces
{
	public interface IBrowseManager
	{
		Task<List<Beer>> GetBeers();
	}
}
