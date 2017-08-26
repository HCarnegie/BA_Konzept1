using System.Data.Entity;
using BA_Konzept.Domain.Entities;
using System.Collections.Generic;

namespace BA_Konzept.Domain.Concrete
{
	public class EFInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
	{
		// DropCreateDatabaseAlways
		// DropCreateDatabaseIfModelChanges
		// CreateDatabaseIfNotExists

		//You can insert data into your database tables during the database initialization process.This will be important if you want to provide some test data for your application or to provide some default master data for your application.
		//To seed data into your database, you have to create custom DB initializer, as you created in DB Initialization Strategy, and override the Seed method.The following example shows how you can provide default data for the Standard table while initializing the School database:

		protected override void Seed(EFDbContext context)
		{
			

			IList<Product> defaultproduct = new List<Product>();

			defaultproduct.Add(new Product() { Name = "Kayak", Description = "A boat for one person", Price = 275.00M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Lifejacket", Description = "Protective and fashionable", Price = 48.95M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Soccer Ball", Description = "FIFA-approved price", Price = 19.50M, Category = "Soccer" });
			defaultproduct.Add(new Product() { Name = "Lifejacket-1", Description = "Protective and fashionable", Price = 48.95M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Soccer Ball-1", Description = "FIFA-approved price", Price = 19.50M, Category = "Soccer" });
			defaultproduct.Add(new Product() { Name = "Lifejacket", Description = "Protective and fashionable", Price = 48.95M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Soccer Ball-2", Description = "FIFA-approved price", Price = 19.50M, Category = "Soccer" });
			defaultproduct.Add(new Product() { Name = "Lifejacket-2", Description = "Protective and fashionable", Price = 48.95M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Soccer Ball-3", Description = "FIFA-approved price", Price = 19.50M, Category = "Soccer" });
			defaultproduct.Add(new Product() { Name = "Lifejacket-3", Description = "Protective and fashionable", Price = 48.95M, Category = "Watersports" });
			defaultproduct.Add(new Product() { Name = "Soccer Ball-4", Description = "FIFA-approved price", Price = 19.50M, Category = "Soccer" });

			context.Products.AddRange(defaultproduct);

			IList<Producttype> defaultproducttype = new List<Producttype>();

			defaultproducttype.Add(new Producttype { Name = "Kayak", Description = "A boat for one person" });
			defaultproducttype.Add(new Producttype { Name = "Lifejacket", Description = "Protective and fashionable" });
			defaultproducttype.Add(new Producttype { Name = "Soccer Ball", Description = "FIFA-approved price" });
			defaultproducttype.Add(new Producttype { Name = "Lifejacket-1", Description = "Protective and fashionable" });
			defaultproducttype.Add(new Producttype { Name = "Soccer Ball-1", Description = "FIFA-approved price" });
			defaultproducttype.Add(new Producttype { Name = "Lifejacket", Description = "Protective and fashionable" });
			defaultproducttype.Add(new Producttype { Name = "Soccer Ball-2", Description = "FIFA-approved price" });
			defaultproducttype.Add(new Producttype { Name = "Lifejacket-2", Description = "Protective and fashionable" });
			defaultproducttype.Add(new Producttype { Name = "Soccer Ball-3", Description = "FIFA-approved price" });
			defaultproducttype.Add(new Producttype { Name = "Lifejacket-3", Description = "Protective and fashionable" });
			defaultproducttype.Add(new Producttype { Name = "Soccer Ball-4", Description = "FIFA-approved price" });

			context.Producttypes.AddRange(defaultproducttype);

			base.Seed(context);
		}
	}
}
