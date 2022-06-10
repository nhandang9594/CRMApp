using Microsoft.AspNetCore.Mvc;
using Antra.CRMApp.WebMVC.Models;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServiceAsync productServiceAsync;
        private readonly IVendorServiceAsync vendorServiceAsync;
        private readonly ICategoryServiceAsync categoryServiceAsync;
        public ProductController(IProductServiceAsync productservice, IVendorServiceAsync vendorservice, ICategoryServiceAsync categoryservice)
        {
            productServiceAsync = productservice;
            vendorServiceAsync = vendorservice;
            categoryServiceAsync = categoryservice;
        }
        public async Task<IActionResult> Index()
        {
            var productCollection = await productServiceAsync.GetAllAsync();
            if (productCollection != null)
                return View(productCollection);

            List<ProductResponseModel> model = new List<ProductResponseModel>();
            return View(model);
        }
        public IActionResult Detail()
        {
            ViewData["Title"] = "Product/Details";
            return View("explain");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //public IActionResult Edit(int id)
        //{
        //    return View();
        //}
    }
}
