using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;

namespace IndiaTourismExplorer.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();

        return categories.Select(x => new CategoryDto
        {
            CategoryId = x.CategoryId,
            Name = x.Name,
            Description = x.Description,
            Icon = x.Icon,
            ImageUrl = x.ImageUrl
        }).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }

        return new CategoryDto
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description,
            Icon = category.Icon,
            ImageUrl = category.ImageUrl
        };
    }
    public async Task<bool> CreateAsync(AdminCategoryDto dto)
    {
        var category = new Domain.Entities.Category
        {
            Name = dto.Name,
            Description = dto.Description,
            Icon = dto.Icon,
            ImageUrl = dto.ImageUrl,
            IsActive = dto.IsActive,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> UpdateAsync(
    int id,
    AdminCategoryDto dto)
    {
        var category = await _repository.GetByIdForAdminAsync(id);

        if (category == null)
        {
            return false;
        }

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.Icon = dto.Icon;
        category.ImageUrl = dto.ImageUrl;
        category.IsActive = dto.IsActive;
        category.UpdatedAt = DateTime.UtcNow;

        _repository.Update(category);
        await _repository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repository.GetByIdForAdminAsync(id);

        if (category == null)
        {
            return false;
        }

        _repository.Remove(category);
        await _repository.SaveChangesAsync();

        return true;
    }
}