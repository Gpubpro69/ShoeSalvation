using ShoeSalvation.Service.DTOs;

namespace ShoeSalvation.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(CreateProductDto productDto);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto productDto);
        Task<ProductDto> GetProductAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(int id);
    }
}
