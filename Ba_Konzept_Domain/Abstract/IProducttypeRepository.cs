using System.Collections.Generic;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept.Domain.Abstract
{
	public interface IProducttypeRepository
	{
		IEnumerable<Producttype> Producttypes { get; }

		void SaveProducttype(Producttype producttype);

		Producttype DeleteProducttype(int producttypeID);
	}
}
