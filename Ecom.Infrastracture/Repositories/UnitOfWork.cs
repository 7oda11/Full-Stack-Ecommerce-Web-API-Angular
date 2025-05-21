using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastracture.Data;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private readonly IImageManagementService imageManagementService;
        private readonly IMapper mapper;
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public ICustomerBasketRepository CustomerBasketRepository { get; }

        public UnitOfWork(AppDbContext _context,IImageManagementService imageManagementService,IMapper mapper,IConnectionMultiplexer connectionMultiplexer)
        {
            context = _context;
            this.imageManagementService = imageManagementService;
            this.mapper = mapper;
            this.connectionMultiplexer = connectionMultiplexer;
            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context,mapper,imageManagementService);
            PhotoRepository = new PhotoRepository(context);
            CustomerBasketRepository = new CustomerBasketRepository(connectionMultiplexer);
        }
    }
}
