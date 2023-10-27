using BusinessObject.DTO;
using BusinessObject.DTO.User;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            string email = HttpContext.Session.GetString("EMAIL");
            var user = await userRepository.GetByEmail(email);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await userRepository.GetById(id);
            ViewData["User"] = user;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProfileDTO model)
        {
            var user = await userRepository.UpdateProfile(id, model);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Update failed";
                return RedirectToAction("Edit", id);
            }
            TempData["SuccessMessage"] = "Update Profile successfully.";
            return RedirectToAction("Index");
        }
    }
}
