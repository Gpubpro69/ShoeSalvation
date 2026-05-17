using ShoeSalvation.Service.DTOs;

namespace ShoeSalvation.Service.Interfaces
{
    public interface IBrandService 
    {
        Task<bool> CreateBrandAsync(CreateBrandDto CreateBrandDto);
        Task<bool> UpdateBrandAsync(UpdateBrandDto CreateBrandDto);

        Task<BrandDto> GetBrandAsync(int id);

        Task<List<BrandDto>> GetAllBrandsAsync();
    }
}
