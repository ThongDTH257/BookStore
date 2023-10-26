using BusinessObject.DTO.Book;
using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IPublisherRepository publisherRepository;
        public BookController(IBookRepository bookRepository, IPublisherRepository publisherRepository)
        {
            this.bookRepository = bookRepository;
            this.publisherRepository = publisherRepository;
        }
        public async Task<IActionResult> Index()
        {
            var books = await bookRepository.GetBooks();
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }
            return View(books);
        
        }
        public async Task<IActionResult> Search(string keyword)
        {
            ViewData["keyword"] = keyword;
            var books = await bookRepository.Search(keyword);
            return View("Index", books);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await bookRepository.Delete(id);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var publishers =  await publisherRepository.GetAllAsync();
            ViewData["Publishers"] = publishers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDTO book)
        {
            await bookRepository.CreateBook(book);
            TempData["SuccessMessage"] = "Create Book successfully";
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookRepository.GetById(id);
            ViewData["Book"] = book;
            var publishers = await publisherRepository.GetAllAsync();
            ViewData["Publishers"] = publishers;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,CreateBookDTO model)
        {
            var book = await bookRepository.UpdateBook(id,model);
            if(book == null)
            {
                TempData["ErrorMessage"] = "Update failed";
                return RedirectToAction("Edit", id);
            }
            TempData["SuccessMessage"] = "Edit book successfully.";
            return RedirectToAction("Index");
        }
    }
}
