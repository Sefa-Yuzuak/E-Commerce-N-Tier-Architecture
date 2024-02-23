using Microsoft.AspNetCore.Mvc;

namespace Demo_ProductUI.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
