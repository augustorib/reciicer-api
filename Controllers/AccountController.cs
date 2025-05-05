using Microsoft.AspNetCore.Mvc;

namespace ReciicerAPI.Controllers
{
    public class AccountController : Controller
    {
      
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}