using AutoMapper;
using BusinessObject.DTO.Book;
using BusinessObject.DTO.User;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<Book, CreateBookDTO>().ReverseMap();
        }
    }
}
