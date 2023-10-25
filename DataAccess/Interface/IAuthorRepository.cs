using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> CreateAuthor(AuthorDTO model);
    }
}
