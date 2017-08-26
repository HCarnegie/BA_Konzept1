using System.Collections.Generic;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept1.Models
{
	public class ProductsListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public PagingInfo PagingInfo { get; set; }
		public string CurrentCategory { get; set; }
	}
}