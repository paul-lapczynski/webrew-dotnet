using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webrew_dotnet.Helpers.Startup
{
	public class ObjectIdModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			var modelName = bindingContext.ModelName;

			// Try to fetch the value of the argument by name
			var valueProviderResult =
				bindingContext.ValueProvider.GetValue(modelName);

			if (valueProviderResult == ValueProviderResult.None)
			{
				return Task.CompletedTask;
			}

			bindingContext.ModelState.SetModelValue(modelName,
				valueProviderResult);

			var value = valueProviderResult.FirstValue;

			// Check if the argument value is null or empty
			if (string.IsNullOrEmpty(value))
			{
				bindingContext.Result = ModelBindingResult.Success(ObjectId.Empty);
				return Task.CompletedTask;
			}

			var model = new ObjectId(value);
			bindingContext.Result = ModelBindingResult.Success(model);
			return Task.CompletedTask;
		}
	}
}
