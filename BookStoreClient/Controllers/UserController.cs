using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
