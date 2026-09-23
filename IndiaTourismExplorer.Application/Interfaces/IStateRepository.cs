using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IStateRepository
{
    Task<List<State>> GetAllAsync();

    Task<State?> GetByIdAsync(int id);

    Task AddAsync(State state);

    void Update(State state);

    void Delete(State state);

    Task SaveChangesAsync();

    Task<State?> GetByIdForAdminAsync(int id);
    void Remove(State state);




}