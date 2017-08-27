using System.Collections.Generic;
using System.Threading.Tasks;
using BA_Konzept.Domain.Entities;
using BA_Konzept.Domain.Abstract;

namespace BA_Konzept.Domain.Concrete
{
	public class ProducttypeRepository : IProducttypeRepository
	{
		private EFDbContext context = new EFDbContext();

		public IEnumerable<Producttype> Producttypes => context.Producttypes;

		public async Task<int> SaveProducttypeAsync(Producttype producttype)
		{

			if (producttype.ProducttypeID == 0)
			{
				context.Producttypes.Add(producttype);
			}
			else
			{
				Producttype dbEntry = context.Producttypes.Find(producttype.ProducttypeID);
				if (dbEntry != null)
				{
					dbEntry.Name = producttype.Name;
					dbEntry.Description = producttype.Description;
				}
			}
			return await context.SaveChangesAsync();
		}

		public async Task<Producttype> DeleteProducttypeAsync(int producttypeID)
		{
			Producttype dbEntry = context.Producttypes.Find(producttypeID);
			if (dbEntry != null)
			{
				context.Producttypes.Remove(dbEntry);
				await context.SaveChangesAsync();
			}
			return dbEntry;
		}
	}
}
