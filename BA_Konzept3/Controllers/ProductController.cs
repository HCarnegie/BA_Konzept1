﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BA_Konzept.Domain.Abstract;
using BA_Konzept.Domain.Entities;
//using BA_Konzept3.Models;

namespace BA_Konzept3.Controllers
{
    public class ProductController : Controller
    {
		private IProductRepository repository;
		public int PageSize = 5;

		public ProductController(IProductRepository productRepository)
		{
			this.repository = productRepository;
		}

		//public ViewResult List(string category, int page = 1)
		//{
		//	ProductsListViewModel model = new ProductsListViewModel
		//	{
		//		Products = repository.Products
		//		.Where(p => category == null || p.Category == category)
		//		.OrderBy(p => p.ProductID)
		//		.Skip((page - 1) * PageSize)
		//		.Take(PageSize),
		//		PagingInfo = new PagingInfo
		//		{
		//			CurrentPage = page,
		//			ItemsPerPage = PageSize,
		//			TotalItems = repository.Products.Count()
		//		},
		//		CurrentCategory = category
		//	};
		//	return View(model);
		//}
	}
}