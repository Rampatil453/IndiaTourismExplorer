using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Infrastructure.Repositories
{
    public sealed class TripRepository:ITripRepository
    {
        private readonly TourismDbContext _db;
        public TripRepository(TourismDbContext db)
        {
            _db = db;
        }
        public Task<List<Trip>> ListMineAsync(string userId)
        {
           return _db.Trips.AsNoTracking().Where(x => x.UserId == userId)
                .OrderByDescending(x => x.TripId).ToListAsync();
        }
        public Task<Trip?> GetMineAsync(int id,string userId)
        {
           return _db.Trips.FirstOrDefaultAsync(x => x.TripId == id && x.UserId == userId);
        }
        public Task<Trip?> GetAsync(int id)
        {
            return _db.Trips.FirstOrDefaultAsync(x => x.TripId == id);
        }
        public Task<List<Trip>> ListAllAsync()
        {
            return _db.Trips.AsNoTracking().OrderByDescending(x => x.TripId).ToListAsync();
        }
        public async Task AddAsync (Trip trip)
        {
            await _db.Trips.AddAsync(trip);
        }
        public void Delete(Trip trip)
        {
            _db.Trips.Remove(trip);
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
