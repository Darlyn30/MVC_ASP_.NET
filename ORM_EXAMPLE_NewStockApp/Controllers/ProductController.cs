using Application.ViewModels;
using Application.Services;
using Database.Context;
using Microsoft.AspNetCore.Mvc;

namespace ORM_EXAMPLE_NewStockApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ApplicationContext _context)
        {
            _service = new(_context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllViewModel());
        }

        //redirect the view with a parameter
        public IActionResult Create()
        {
            return View("SaveProduct", new SaveProductViewModel());
        }

        [HttpPost]

        public async Task<IActionResult> Create(SaveProductViewModel model)
        {

            if(!ModelState.IsValid)
            {
                return View("SaveProduct", model);
            }
            await _service.AddAsync(model);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveProduct", await _service.GetByIdSaveViewModel(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", model);
            }
            await _service.Update(model);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View( await _service.GetByIdSaveViewModel(id));
        }

        [HttpPost]

        //redirect controller & action
        public async Task<IActionResult> DeletePost(int id)
        {
            await _service.Delete(id);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
    }
}
