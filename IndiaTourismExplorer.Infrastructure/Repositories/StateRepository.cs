using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IndiaTourismExplorer.Infrastructure.Repositories;

public class StateRepository : IStateRepository
{
    private readonly TourismDbContext _context;

    public StateRepository(TourismDbContext context)
    {
        _context = context;
    }

    public async Task<List<State>> GetAllAsync()
    {
        return await _context.States
            .Where(x => x.IsActive)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<State?> GetByIdAsync(int id)
    {
        return await _context.States
            .FirstOrDefaultAsync(x => x.StateId == id && x.IsActive);
    }

    public async Task AddAsync(State state)
    {
        await _context.States.AddAsync(state);
    }

    public void Update(State state)
    {
        _context.States.Update(state);
    }

    public void Delete(State state)
    {
        state.IsActive = false;
        state.UpdatedAt = DateTime.UtcNow;

        _context.States.Update(state);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}