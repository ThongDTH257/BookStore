using BusinessObject.DTO.Book;
using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookStoreAPIs.Controllers
{
    public class BooksController : ODataController
    {
        private readonly IBookRepository bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        [EnableQuery]
        public async Task<IActionResult> Get() => Ok(await bookRepository.GetAllAsync());
        [EnableQuery]
        public async Task<IActionResult> Get(int key)
        {
            var book = await bookRepository.GetById(key);
            return Ok(book);
        }
        public async Task<IActionResult> Post([FromBody] CreateBookDTO model)
        {
            var book = await bookRepository.CreateBook(model);
            if (book == null) return BadRequest("Created book failed");
            return Created(book);
        }
        [EnableQuery]
        [Route("odata/[controller]/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CreateBookDTO model)
        {
            var book = await bookRepository.UpdateBook(id, model);
            if (book == null) return NotFound("Book Id does not exist");
            return Updated(book);
        }

        [EnableQuery]
        [Route("odata/[controller]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await bookRepository.Delete(id);
            if(!result) return NotFound("Cannot find with book id: " + id);
            return Ok();
        }
    }
}
