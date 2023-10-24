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
    }
}
