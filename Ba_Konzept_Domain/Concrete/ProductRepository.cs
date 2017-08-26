using System.Collections.Generic;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class ProductRepository : IProductRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Product> Products
		{
			get { return context.Products; }
		}
	}
}
