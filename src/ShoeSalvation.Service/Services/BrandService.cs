using ShoeSalvation.Domain.Entities;
using ShoeSalvation.Repository.Repositories;
using ShoeSalvation.Service.DTOs;
using ShoeSalvation.Service.Interfaces;

namespace ShoeSalvation.Service.Services
{
    public class BrandService : IBrandService
    {
        private readonly IGenericRepository<Brand> _repository;

        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository;
        }
        public Task<bool> CreateBrandAsync(CreateBrandDto CreateBrandDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<BrandDto>> GetAllBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto> GetBrandAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBrandAsync(UpdateBrandDto CreateBrandDto)
        {
            throw new NotImplementedException();
        }
    }
}
