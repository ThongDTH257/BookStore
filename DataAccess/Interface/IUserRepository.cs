using BusinessObject.DTO.User;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> Login(LoginDTO model);
        Task<Boolean> Register(RegisterDTO model);
    }
}
