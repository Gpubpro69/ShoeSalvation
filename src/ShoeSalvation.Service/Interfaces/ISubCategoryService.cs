using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Service.DTOs;


namespace ShoeSalvation.Service.Interfaces
{
    public interface ISubCategoryService
    {
        Task<bool> CreateSubCategoryAsync(CreateSubCategoryDto createSubCategoryDto);
        Task<bool> UpdateSubCategoryAsync(int id, UpdateSubCategoryDto updateSubCategoryDto);
        Task<bool> DeleteSubCategoryAsync(int id);
        Task<SubCategoryDto> GetSubCategoryAsync(int id);
        Task<List<SubCategoryDto>> GetAllSubCategoriesAsync();
    }
}
