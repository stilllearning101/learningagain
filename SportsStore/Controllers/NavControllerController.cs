using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class NavControllerController : Controller
    {
        private IProductsRepository repository;
        public NavControllerController(IProductsRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
        }
}