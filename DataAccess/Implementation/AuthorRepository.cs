using AutoMapper;
using BusinessObject.Models;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly StoreDbContext dbContext;
        private readonly IMapper mapper;
        public AuthorRepository(StoreDbContext context , IMapper mapper) : base(context)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }
    }
}
