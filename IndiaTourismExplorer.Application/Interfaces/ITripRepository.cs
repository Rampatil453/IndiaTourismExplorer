using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> ListMineAsync(string userId);
        Task<Trip?> GetMineAsync(int id, string userId);
        Task<Trip?> GetAsync(int id);
        Task<List<Trip>> ListAllAsync();
        Task AddAsync(Trip trip);
        void Delete(Trip trip);
        Task SaveAsync();
    }
}
