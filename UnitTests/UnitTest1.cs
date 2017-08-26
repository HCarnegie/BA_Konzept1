using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Entities;
using BA_Konzept1.Controllers;
using BA_Konzept1.Models;
using BA_Konzept1.HtmlHelpers;

namespace UnitTests
{
	[TestClass]
	public class UnitTest1
	{

		[TestMethod]
		public void Can_Paginate()
		{

			// Arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new Product[] {
				new Product {ProductID = 1, Name = "P1"},
				new Product {ProductID = 2, Name = "P2"},
				new Product {ProductID = 3, Name = "P3"},
				new Product {ProductID = 4, Name = "P4"},
				new Product {ProductID = 5, Name = "P5"}
			});

			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			// Act
			// ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;
			ProductsListViewModel result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;

			// Assert
			Product[] prodArray = result.Products.ToArray();
			Assert.IsTrue(prodArray.Length == 2);
			Assert.AreEqual(prodArray[0].Name, "P4");
			Assert.AreEqual(prodArray[1].Name, "P5");
		}

		[TestMethod]
		public void Can_Generate_Page_Links()
		{

			// Arrange - define an HTML helper - we need to do this
			// in order to apply the extension method
			HtmlHelper myHelper = null;

			// Arrange - create PagingInfo data
			PagingInfo pagingInfo = new PagingInfo
			{
				CurrentPage = 2,
				TotalItems = 28,
				ItemsPerPage = 10
			};

			// Arrange - set up the delegate using a lambda expression
			Func<int, string> pageUrlDelegate = i => "Page" + i;

			// Act
			MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

			// Assert
			Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
				+ @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
				+ @"<a class=""btn btn-default"" href=""Page3"">3</a>",
				result.ToString());
		}

		[TestMethod]
		public void Can_Send_Pagination_View_Model()
		{

			// Arrange
			Mock<IProductRepository> mock = new Mock<IProductRepository>();
			mock.Setup(m => m.Products).Returns(new Product[] {
				new Product {ProductID = 1, Name = "P1"},
				new Product {ProductID = 2, Name = "P2"},
				new Product {ProductID = 3, Name = "P3"},
				new Product {ProductID = 4, Name = "P4"},
				new Product {ProductID = 5, Name = "P5"}
			});

			// Arrange
			ProductController controller = new ProductController(mock.Object);
			controller.PageSize = 3;

			// Act
			ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

			// Assert
			PagingInfo pageInfo = result.PagingInfo;
			Assert.AreEqual(pageInfo.CurrentPage, 2);
			Assert.AreEqual(pageInfo.ItemsPerPage, 3);
			Assert.AreEqual(pageInfo.TotalItems, 5);
			Assert.AreEqual(pageInfo.TotalPages, 2);
		}

		/// <summary>
		/// This creates a mock repository implemention that contains repeating categories and categories that are not in order. I assert that the duplicates are removed and that alphabetical ordering is imposed.  
		/// </summary>
		//[TestMethod]
		//public void Can_Select_Categories()
		//{
		//	// Arrange
		//	// create the controller 
		//	Mock<IProductRepository> mock = new Mock<IProductRepository>();
		//	mock.Setup(m => m.Products).Returns(new Product[] {
		//		new Product {ProductID = 1, Name = "P1", Category = "Apples"},
		//		new Product {ProductID = 2, Name = "P2", Category = "Apples"},
		//		new Product {ProductID = 3, Name = "P3", Category = "Plums"},
		//		new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
		//		});

		//	// Arrenge 
		//	// NavController target = new NavController(mock.Object);

		//	// Act = get the set of categories
		//	// string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

		//	// Assert
		//	Assert.AreEqual(results.Length, 3);
		//	Assert.AreEqual(results[0], "Apples");
		//	Assert.AreEqual(results[1], "Oranges");
		//	Assert.AreEqual(results[2], "Plums");
		//}
	}


}
