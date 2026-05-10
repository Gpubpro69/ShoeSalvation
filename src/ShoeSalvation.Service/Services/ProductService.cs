
using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Repository.Repositories;
using ShoeSalvation.Service.DTOs;
using ShoeSalvation.Service.Interfaces;

namespace ShoeSalvation.Service.Services
{
    
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateProductAsync(CreateProductDto productDto)
        {
            await _repository.AddAsync(new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                SubCategoryId = productDto.SubCategoryId,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });
            await _repository.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                BrandName = p.Brand != null ? p.Brand.Name : string.Empty,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty,
                SubCategoryName = p.SubCategory != null ? p.SubCategory.Name : string.Empty,
                IsActive = p.IsActive
            }).ToList();
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new InvalidOperationException($"Product with id {id} not found.");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                BrandName = product.Brand != null ? product.Brand.Name : string.Empty,
                CategoryName = product.Category != null ? product.Category.Name : string.Empty,
                SubCategoryName = product.SubCategory != null ? product.SubCategory.Name : string.Empty,
                IsActive = product.IsActive
            };
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;
            if (productDto.Name != null) product.Name = productDto.Name;
            if (productDto.Description != null) product.Description = productDto.Description;
            if (productDto.BrandId != null) product.BrandId = productDto.BrandId.Value;
            if (productDto.CategoryId != null) product.CategoryId = productDto.CategoryId.Value;
            if (productDto.SubCategoryId != null) product.SubCategoryId = productDto.SubCategoryId.Value;
            product.UpdatedAt = DateTime.UtcNow;
            _repository.Update(product);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
