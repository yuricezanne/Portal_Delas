using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
