using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Author> CreateAuthor(AuthorDTO model)
        {
            var author = mapper.Map<Author>(model);
            dbContext.Authors.Add(author);
            var isSuccess = await dbContext.SaveChangesAsync() > 0;
            if (!isSuccess)
            {
                return null;
            }
            return author;
        }

        public async Task<Author> UpdateAuthor(int id,AuthorDTO model)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(p => p.Id == id);
            if (author != null)
            {
                mapper.Map(model, author);
                dbContext.Update(author);
                var isSuccess = await dbContext.SaveChangesAsync() > 0;
                if (!isSuccess)
                {
                    return null;
                }
                return author;
            }
            return  author;
        }
    }
}
