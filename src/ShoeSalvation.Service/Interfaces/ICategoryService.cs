using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Service.DTOs;

namespace ShoeSalvation.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<bool> UpdateCategoryAsync(UpdateBrandDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task <CategoryDto>GetCategoryAsync(int id);

        Task<List<CategoryDto>> GetAllCategoriesAsync();
    }
}
