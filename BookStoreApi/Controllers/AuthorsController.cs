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
    }
}
