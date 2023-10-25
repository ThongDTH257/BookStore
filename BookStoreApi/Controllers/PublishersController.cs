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
        public async Task<IActionResult> Post([FromBody] PublisherDTO model)
        {
            var publisher = await publisherRepository.CreatePublisher(model);
            if (publisher == null) return BadRequest("Create failed");
            return Created(publisher);
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
