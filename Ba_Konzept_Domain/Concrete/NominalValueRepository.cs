using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;


namespace BA_Konzept.Domain.Concrete
{
	public class NominalValueRepository : INominalValueRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<NominalValue> NominalValues
		{
			get { return context.NominalValues; }
		}
	}
}
