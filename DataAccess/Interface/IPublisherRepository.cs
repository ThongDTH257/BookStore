﻿using BusinessObject.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<Publisher> CreatePublisher(PublisherDTO model);
        Task<Publisher> UpdatePublisher(int id,PublisherDTO model);
    }
}
