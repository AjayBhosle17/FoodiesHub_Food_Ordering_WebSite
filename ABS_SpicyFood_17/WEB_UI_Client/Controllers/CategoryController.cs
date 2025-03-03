using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace WEB_UI_Client.Controllers
{
    public class CategoryController : Controller
    {
       ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create() { 
        
            return View();
        }
    }
}
