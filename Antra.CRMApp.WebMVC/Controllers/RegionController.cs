using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController(IRegionServiceAsync reg)
        {
            regionServiceAsync = reg;
        }
        public async Task<IActionResult> Index()
        {
            var result = await regionServiceAsync.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegionModel model)
        {
            if (ModelState.IsValid)
            {
                await regionServiceAsync.AddRegionAsync(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.IsEdit = false;
            var regModel = await regionServiceAsync.GetRegionForEditAsync(id);
            return View(regModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RegionModel model)
        {
            ViewBag.IsEdit = false;
            if (ModelState.IsValid)
            {
                await regionServiceAsync.UpdateRegionAsync(model);
                ViewBag.IsEdit = true;
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await regionServiceAsync.DeleteRegionAsync(id);
            return RedirectToAction("Index");
        }
    }
}
