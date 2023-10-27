using BusinessObject.DTO;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreClient.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherController(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public async Task<IActionResult> Index()
        {
            var publishers = await publisherRepository.GetAllAsync();
            if (TempData != null)
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];
            }
            return View(publishers);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await publisherRepository.Delete(id);
            TempData["SuccessMessage"] = "Delete Publisher successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PublisherDTO model)
        {
            var publisher = await publisherRepository.CreatePublisher(model);
            if ( publisher== null)
            {
                TempData["ErrorMessage"] = "Email already exist!";
                return View();
            }
            TempData["SuccessMessage"] = "Create Publisher successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await publisherRepository.GetById(id);
            ViewData["Publisher"] = publisher;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PublisherDTO model)
        {
            var publisher = await publisherRepository.UpdatePublisher(id, model);
            if (publisher == null)
            {
                TempData["ErrorMessage"] = "Update failed";
                return RedirectToAction("Edit", id);
            }
            TempData["SuccessMessage"] = "Edit Publisher successfully.";
            return RedirectToAction("Index");
        }
    }
}
