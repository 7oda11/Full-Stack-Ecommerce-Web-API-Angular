using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext _context):base(_context)
        {
            context = _context;
        }
    }
}
