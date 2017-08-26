using System.Collections.Generic;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept1.Models
{
	public class ProducttypesListViewModel
	{
		public IEnumerable<Producttype> Producttypes { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string ReturnUrl { get; set; }
	}
}