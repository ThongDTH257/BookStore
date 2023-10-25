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
    public class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        private readonly StoreDbContext dbContext;
        private readonly IMapper mapper;
        public PublisherRepository(StoreDbContext context, IMapper mapper) : base(context)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        public async Task<Publisher> CreatePublisher(PublisherDTO model)
        {
            var publisher = mapper.Map<Publisher>(model);
            dbContext.Publishers.Add(publisher);
            var isSuccess = await dbContext.SaveChangesAsync() > 0;
            if (!isSuccess)
            {
                return null;
            }
            return publisher;
        }

        public async Task<Publisher> UpdatePublisher(int id,PublisherDTO model)
        {
            var publisher = await dbContext.Publishers.FirstOrDefaultAsync(p=>p.Id == id);
            if(publisher != null)
            {
                mapper.Map(model, publisher);
                dbContext.Update(publisher);
                var isSuccess = await dbContext.SaveChangesAsync() > 0;
                if (!isSuccess)
                {
                    return null;
                }
                return publisher;
            }
            return publisher;
        }
    }
}
