using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastracture.Data;
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

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }
        public UnitOfWork(AppDbContext _context,IImageManagementService imageManagementService,IMapper mapper)
        {
            context = _context;
            this.imageManagementService = imageManagementService;
            this.mapper = mapper;
            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context,mapper,imageManagementService);
            PhotoRepository = new PhotoRepository(context);
        }
    }
}
