using ShopRepository.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Task3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productRepository = new ProductRepository(Constants.ConnectionString);
            var products = productRepository.GetProducts();
            return View(products);
        }

        public ActionResult AddToBasket(int id)
        {
            //TODO: Add Async logic gere

            return RedirectToAction("Index");
        }

        /*private async Task<int> CalculateCost(int id)
        {
            var productRepository = new ProductRepository(Constants.ConnectionString);
            var products = productRepository.GetProducts();
            var cost = 
            return 
        }*/
    }
}