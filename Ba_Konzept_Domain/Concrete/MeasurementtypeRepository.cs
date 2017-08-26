using System;
using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class MeasurementtypeRepository : IMeasurementtypeRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Measurementtype> Measurementtypes
		{
			get { return context.Measurementtypes; }
		}
	}
}
