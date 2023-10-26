using AutoMapper;
using BusinessObject.DTO.Book;
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
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly StoreDbContext dbContext;
        private readonly IMapper mapper;
        public BookRepository(StoreDbContext context, IMapper mapper) : base(context)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public IEnumerable<Book> GetBookDynamic()
        {
            return dbContext.Books.AsQueryable();
        }

        public async Task<Book> CreateBook(CreateBookDTO model)
        {
            var book = mapper.Map<Book>(model); 
            dbContext.Books.Add(book);
            var isSuccess = await dbContext.SaveChangesAsync() > 0;
            return book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await dbContext.Books.Include(b => b.Publisher).ToListAsync();
            return books;
        }

        public async Task<Book> UpdateBook(int id, CreateBookDTO model)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(b=>b.Id == id);
            if(book != null) 
            {
                mapper.Map(model, book);
                dbContext.Update(book);
                var isSuccess = await dbContext.SaveChangesAsync() > 0;
                if(!isSuccess)
                {
                    return null;
                }
            }
            return book;
        }

        public async Task<IEnumerable<Book>> Search(string name)
        {
            var books = await dbContext.Books.Where(b => b.Title.Contains(name)).ToListAsync();
            return books;
        }
    }
}
