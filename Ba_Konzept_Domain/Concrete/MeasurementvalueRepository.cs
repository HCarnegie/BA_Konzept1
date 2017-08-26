using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class MeasurementvalueRepository : IMeasurementvalueRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Measurementvalue> Measurementvalues
		{
			get { return context.Measurementvalues; }
		}
	}
}
