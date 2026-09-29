using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto?> GetByIdAsync(int id);
    Task<bool> CreateAsync(AdminCategoryDto dto);

    Task<bool> UpdateAsync(int id, AdminCategoryDto dto);

    Task<bool> DeleteAsync(int id);
}