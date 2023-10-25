using BusinessObject.DTO;
using BusinessObject.DTO.Book;
using BusinessObject.Models;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookStoreAPIs.Controllers
{
    public class PublishersController : ODataController
    {
        private readonly IPublisherRepository publisherRepository;
        public PublishersController(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        [EnableQuery]
        public async Task<List<Publisher>> Get() => await publisherRepository.GetAllAsync();
        [EnableQuery]
        public async Task<ActionResult<Publisher>> Get(int key)
        {
            var publisher = await publisherRepository.GetById(key);
            return Ok(publisher);
        }
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] PublisherDTO model)
        {
            var publisher = await publisherRepository.CreatePublisher(model);
            if (publisher == null) return BadRequest("Create failed");
            return Created(publisher);
        }
        [EnableQuery]
        [Route("odata/[controller]/{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] PublisherDTO model)
        {
            var publisher = await publisherRepository.UpdatePublisher(id, model);
            if (publisher == null) return NotFound("Publisher Id does not exist");
            return Updated(publisher);
        }

        [EnableQuery]
        [Route("odata/[controller]/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await publisherRepository.Delete(id);
            if (!result) return NotFound("Cannot find with publisher id: " + id);
            return Ok();
        }
    }
}
