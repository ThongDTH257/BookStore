using BookStoreClient.Models;
using BusinessObject.DTO.User;
using BusinessObject.Models;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BookStoreClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly HttpClient client = null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }
        [HttpGet]
        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("ROLE");
            if (role == "admin")
            {
                return RedirectToAction("Index", "Book");
            }
            if(role == "user")
            {
                return RedirectToAction("Index", "User");
            }
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO model)
        {
            var user = await userRepository.Login(model);
            if (user != null)
            {
                HttpContext.Session.SetString("EMAIL", model.Email);
                HttpContext.Session.SetInt32("USERID", user.Id);
                if(user.RoleId == 1)
                {
                    HttpContext.Session.SetString("ROLE", "admin");
                }
                else
                {
                    HttpContext.Session.SetString("ROLE", "user");
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        {
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var result = await userRepository.Register(model);
            if (!result) 
            {
                TempData["ErrorMessage"] = "Email already exists.";
                return RedirectToAction("Register");
            }
            TempData["SuccessMessage"] = "Register successfully! ";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}