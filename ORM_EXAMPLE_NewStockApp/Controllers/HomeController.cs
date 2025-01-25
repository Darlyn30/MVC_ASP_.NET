using System.Diagnostics;
using Application.Services;
using Database.Context;
using Microsoft.AspNetCore.Mvc;
using ORM_EXAMPLE_NewStockApp.Models;

namespace ORM_EXAMPLE_NewStockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _service;

        public HomeController(ApplicationContext _context)
        {
            _service = new(_context);
        }

        // just return the view home receiving the view model of product
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllViewModel());
        }
    }
}
