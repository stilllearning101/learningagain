using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List(string category, int Page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)//Matching category property are selected
                .OrderBy(i => i.ProductID)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PageInfo
                {
                    CurrentPage = Page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(i => i.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}