using Microsoft.AspNetCore.Mvc;

namespace WEB_UI_Client.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
