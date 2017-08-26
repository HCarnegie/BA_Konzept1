
using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class TypedataRepository : ITypedataRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Typedata> Typedatas
		{
			get { return context.Typedatas; }
		}
	}
}
