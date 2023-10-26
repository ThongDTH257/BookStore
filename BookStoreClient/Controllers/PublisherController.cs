using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
