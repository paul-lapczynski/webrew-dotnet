﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webrew.Interfaces.Beer;

namespace Webrew.Managers.Interfaces
{
	public interface IHomeManager
	{
		Task<Beer> AddBeer(Beer coffee);

		Task<List<Beer>> GetBeers();
	}
}
