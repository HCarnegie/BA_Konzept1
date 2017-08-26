using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class MeasurementRepository : IMeasurementRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Measurement> Measurements
		{
			get { return context.Measurements; }
		}
	}
}