using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TapMapWeb.Models;

namespace TapMapWeb.Controllers
{
	public abstract class ModelControllerBase<T> : ControllerBase where T : ModelBase
	{
		public abstract RepositoryBase<T> Repository { get; set; }

		public ModelControllerBase(RepositoryBase<T> repository)
		{
			Repository = repository;
		}
	}
}