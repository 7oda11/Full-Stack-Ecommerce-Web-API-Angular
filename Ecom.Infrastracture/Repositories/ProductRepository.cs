using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;

        public ProductRepository(AppDbContext _context,IMapper mapper,IImageManagementService imageManagementService) :base(_context)
        {
            context = _context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;
            var product=mapper.Map<Product>(productDTO);
           await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var imagePath = await imageManagementService.AddImageAsync(productDTO.Photos, productDTO.Name);
            var photo = imagePath.Select(path => new Photo 
            {
                ImageName=path,
                ProductId=product.Id
            }).ToList();
           await context.Photos.AddRangeAsync(photo);
           await context.SaveChangesAsync();
            return true;


        }

        

        public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO is null) return false;

            var findProduct = await context.Products
       .Include(p => p.Photos)
       .Include(p => p.Category)
       .FirstOrDefaultAsync(p => p.Id == updateProductDTO.Id);

            if (findProduct is  null) return false;

            // Correct mapping: apply values from DTO to existing entity
            mapper.Map(updateProductDTO, findProduct);

            // Remove old photos from storage
            var oldPhotos = await context.Photos.Where(p => p.ProductId == findProduct.Id).ToListAsync();
            foreach (var photo in oldPhotos)
            {
                 imageManagementService.DeleteImageAsync(photo.ImageName);
            }

            // Remove from DB
            context.Photos.RemoveRange(oldPhotos);

            // Add new images
            var newImagePaths = await imageManagementService.AddImageAsync(updateProductDTO.Photos, updateProductDTO.Name);
            var newPhotos = newImagePaths.Select(path => new Photo
            {
                ImageName = path,
                ProductId = updateProductDTO.Id
            }).ToList();

            await context.Photos.AddRangeAsync(newPhotos);

            await context.SaveChangesAsync();

            return true;
        }
        public async Task DeleteAsync(Product product)
        {
            var photo = await context.Photos.Where(p => p.ProductId == product.Id).ToListAsync();
            foreach (var item in photo)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
