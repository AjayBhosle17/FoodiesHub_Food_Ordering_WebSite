using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Diagnostics;
using WEB_UI_Client.Models;

namespace WEB_UI_Client.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService _service;

        public HomeController(ICategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetAll();
            return View(categories);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
