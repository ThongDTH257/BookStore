using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await authorRepository.GetAllAsync();
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }
            return View(authors);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await authorRepository.Delete(id);
            TempData["SuccessMessage"] = "Delete Author successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AuthorDTO authorDTO)
        {
            var author = await authorRepository.CreateAuthor(authorDTO);
            if (author == null)
            {
                TempData["ErrorMessage"] = "Email already exist!";
                return View();
            }
            TempData["SuccessMessage"] = "Create Author successfully";
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var author = await authorRepository.GetById(id);
            ViewData["Author"] = author;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorDTO model)
        {
            var author = await authorRepository.UpdateAuthor(id, model);
            if (author == null)
            {
                TempData["ErrorMessage"] = "Update failed";
                return RedirectToAction("Edit", id);
            }
            TempData["SuccessMessage"] = "Edit Author successfully.";
            return RedirectToAction("Index");
        }
    }
}
