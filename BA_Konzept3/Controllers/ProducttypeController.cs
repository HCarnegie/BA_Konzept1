using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Concrete;
using BA_Konzept.Domain.Entities;
//using BA_Konzept3.Models;

namespace BA_Konzept3.Controllers
{
    public class ProducttypeController : ApiController
    {
		private IProducttypeRepository repository { get; set; }
		public int PageSize = 5;


		public ProducttypeController()
		{
			//IProducttypeRepository producttypeRepository
			this.repository = (IProducttypeRepository)GlobalConfiguration.Configuration.
				DependencyResolver.GetService(typeof(IProducttypeRepository));
			//this.repository = producttypeRepository;
		}


	    public IEnumerable<Producttype> GetProducttypes()
	    {
		    return this.repository.Producttypes;
	    }

	    public Producttype GetProducttype(int id)
	    {
		    return this.repository.Producttypes.FirstOrDefault(p => p.ProducttypeID == id);
	    }


		/// <summary>
		/// Add a new Producttype to Context and check if the passed object is valid.
		/// </summary>
		/// <param name="producttype"></param>
		/// <returns></returns>
	    public async Task<IHttpActionResult> PostProducttype(Producttype producttype)
	    {
		    if (ModelState.IsValid)
		    {
			    await this.repository.SaveProducttypeAsync(producttype);
			    return Ok();
		    }
		    else
		    {
			    return BadRequest(ModelState);
		    }
	    }

		public async Task DeleteProducttype(int id)
	    {
		    await this.repository.DeleteProducttypeAsync(id);
	    }



		//public ViewResult List(int page = 1)
		//{
		//	ProducttypesListViewModel model = new ProducttypesListViewModel
		//	{
		//		Producttypes = repository.Producttypes
		//		.OrderBy(p => p.ProducttypeID)
		//		.Skip((page - 1) * PageSize)
		//		.Take(PageSize),
		//		PagingInfo = new PagingInfo
		//		{
		//			CurrentPage = page,
		//			ItemsPerPage = PageSize,
		//			TotalItems = repository.Producttypes.Count()
		//		},
		//	};
		//	return View(model);
		//}

		//public ViewResult Edit(int producttypeId)
		//{
		//	Producttype producttype = repository.Producttypes
		//		.FirstOrDefault(p => p.ProducttypeID == producttypeId);
		//	return View(producttype);
		//}

		//[System.Web.Mvc.HttpPost]
		//public ActionResult Edit(Producttype producttype, string returnUrl)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		//Producttype producttype = repository.Producttypes
		//		//	.FirstOrDefault(p => p.ProducttypeID == producttypeId);

		//		repository.SaveProducttype(producttype);
		//		TempData["message"] = string.Format("{0} has been saved", producttype.Name);
		//		return RedirectToAction("List", new { returnUrl });
		//	}
		//	else
		//	{
		//		return View(producttype);
		//	}

		//}

		//public ViewResult Create()
		//{
		//	return View("Edit", new Producttype());
		//}

		//[System.Web.Mvc.HttpPost]
		//public ActionResult Delete(int producttypeId, string returnUrl)
		//{
		//	Producttype deletedProducttype = repository.DeleteProducttype(producttypeId);

		//	if (deletedProducttype != null)
		//	{
		//		TempData["message"] = string.Format("{0} was deleted", deletedProducttype.Name);
		//	}
		//	return RedirectToAction("List", new { returnUrl });
		//}
	}
}