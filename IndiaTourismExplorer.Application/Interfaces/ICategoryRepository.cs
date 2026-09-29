using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);
    Task<Category?> GetByIdForAdminAsync(int id);
    Task AddAsync(Category category);
    void Update(Category category);
    void Remove(Category category);
    Task SaveChangesAsync();
}