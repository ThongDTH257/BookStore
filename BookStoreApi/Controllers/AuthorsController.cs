using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookStoreAPIs.Controllers
{
    public class AuthorsController : ODataController
    {
        private readonly IAuthorRepository authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [EnableQuery]
        public async Task<ActionResult<List<Author>>> Get() => Ok(await authorRepository.GetAllAsync());
        [EnableQuery]
        public async Task<IActionResult> Post(AuthorDTO model)
        {
            var author = await authorRepository.CreateAuthor(model);
            if (model == null) return BadRequest("Cannot create author");
            return Ok(author);
        }
        [EnableQuery]
        [Route("odata/[controller]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await authorRepository.Delete(id);
            if (!result) return NotFound("Cannot find with author id: " + id);
            return Ok();
        }
    }
}
