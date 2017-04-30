using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using System.Linq;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Controllers
{

    [Authorize]
    public class AdminController : Controller
    {
        private IProductsRepository repository;
        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }
        public ViewResult Edit(int productId)
        {
            Products product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Products product)
        {
            if (ModelState.IsValid) // chech that the model binder has been able to validate the data
                // submitted to the user by reading the value of the modelstate.isvalid property
            {
                repository.SaveProduct(product);
                // store message using TempData feature, this is a key/value dictionary similar to the session
                // data and view bag feature. The main difference is the temp data is deleted at the end of the 
                // HTTP request.
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Products());
        }

        [HttpPost]
        public ActionResult Delete(int? productId)
        {
            Products deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
/* ViewResult is derived from ActionResult and it is used when you want the framework to render a view
 * return RedirectToAction redirects the browser to Index action method.
 */