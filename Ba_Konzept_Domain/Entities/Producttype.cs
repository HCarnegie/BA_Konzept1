using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Konzept.Domain.Entities
{
	public class Producttype
	{
		public int ProducttypeID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		// ### Relations ### 
		public virtual ICollection<Product> Products { get; set; }
		public virtual ICollection<Typedata> Typedatas { get; set; }

		// ### Constructor ###
		public Producttype()
		{
			Products = new HashSet<Product>();
			Typedatas = new HashSet<Typedata>();
		}
	}
}
