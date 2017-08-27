using System.Collections.Generic;
using System.Threading.Tasks;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept.Domain.Abstract
{
	public interface IProducttypeRepository
	{
		IEnumerable<Producttype> Producttypes { get; }

		Task<int> SaveProducttypeAsync(Producttype producttype);

		Task<Producttype>  DeleteProducttypeAsync(int producttypeID);


	}
}
