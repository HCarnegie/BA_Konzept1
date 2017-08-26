using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Konzept1.Models;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Entities;

namespace BA_Konzept1.Controllers
{
    public class ProducttypeController : Controller
    {
		private IProducttypeRepository repository;
		public int PageSize = 5;

		public ProducttypeController(IProducttypeRepository producttypeRepository)
		{
			this.repository = producttypeRepository;
		}

		public ViewResult List(int page = 1)
		{
			ProducttypesListViewModel model = new ProducttypesListViewModel
			{
				Producttypes = repository.Producttypes
				.OrderBy(p => p.ProducttypeID)
				.Skip((page - 1) * PageSize)
				.Take(PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = PageSize,
					TotalItems = repository.Producttypes.Count()
				},
			};
			return View(model);
		}

		public ViewResult Edit(int producttypeId)
		{
			Producttype producttype = repository.Producttypes
				.FirstOrDefault(p => p.ProducttypeID == producttypeId);
			return View(producttype);
		}

		[HttpPost]
		public ActionResult Edit(Producttype producttype, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				//Producttype producttype = repository.Producttypes
				//	.FirstOrDefault(p => p.ProducttypeID == producttypeId);

				repository.SaveProducttype(producttype);
				TempData["message"] = string.Format("{0} has been saved", producttype.Name);
				return RedirectToAction("List", new { returnUrl });
			}
			else
			{
				return View(producttype);
			}

		}

		public ViewResult Create()
		{
			return View("Edit", new Producttype());
		}

		[HttpPost]
		public ActionResult Delete(int producttypeId, string returnUrl)
		{
			Producttype deletedProducttype = repository.DeleteProducttype(producttypeId);

			if (deletedProducttype != null)
			{
				TempData["message"] = string.Format("{0} was deleted", deletedProducttype.Name);
			}
			return RedirectToAction("List", new { returnUrl });
		}
	}
}