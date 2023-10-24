using BusinessObject.DTO.Book;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetBookDynamic();
        Task<Book> CreateBook(CreateBookDTO model);
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> UpdateBook (int id, CreateBookDTO model);
    }
}
