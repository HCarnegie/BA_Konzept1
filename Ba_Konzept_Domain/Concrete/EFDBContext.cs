using System.Data.Entity;
using BA_Konzept.Domain.Entities;
using System.Collections.Generic;

namespace BA_Konzept.Domain.Concrete
{
	public class EFDbContext : DbContext
	{

		public DbSet<Product> Products { get; set; }
		public DbSet<Producttype> Producttypes { get; set; }
		public DbSet<Typedata> Typedatas { get; set; }
		public DbSet<NominalValue> NominalValues { get; set; }
		public DbSet<Measurementtype> Measurementtypes { get; set; }
		public DbSet<Measurementvalue> Measurementvalues { get; set; }
		public DbSet<Measurement> Measurements { get; set; }

		/// <summary>
		/// Constructor for ZWAU_LineController Database Context 'zwlinemasterdb' 
		/// Can set an initializer.
		/// </summary>
		public EFDbContext() : base("name=EFDbContext")
		{
			
		}
	}
}
