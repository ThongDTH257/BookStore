using AutoMapper;
using BusinessObject.DTO.User;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly StoreDbContext dbContext;
        private readonly IMapper mapper;
        public UserRepository(StoreDbContext context, IMapper mapper) : base(context)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public async Task<User?> Login(LoginDTO model)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u=>u.Email== model.Email && u.Password == model.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<Boolean> Register(RegisterDTO model)
        {
            bool check = false;
            var existing = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
            if(existing != null) 
            { 
                return check; 
            }
            var user = mapper.Map<User>(model);
            dbContext.Users.Add(user);
            var isSuccess = await dbContext.SaveChangesAsync() > 0;
            if (isSuccess) 
            {
                check = true;
            }
            return check;
        }
    }
}
