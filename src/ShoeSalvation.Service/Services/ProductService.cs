
using AutoMapper;
using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Repository.Repositories;
using ShoeSalvation.Service.DTOs;
using ShoeSalvation.Service.Interfaces;

namespace ShoeSalvation.Service.Services
{
    
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CreateProductAsync(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.IsActive = true;
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;
            await _repository.AddAsync(product);
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
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new InvalidOperationException($"Product with id {id} not found.");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto productDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;
            _mapper.Map(productDto, product);
          
            _repository.Update(product);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
