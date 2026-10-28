using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services
{
    public sealed class TripService:ITripService
    {
        private readonly ITripRepository _repo;
        public TripService(ITripRepository repo)
        {
            _repo = repo;
        }
        private static TripDto Map(Trip t) => new()
        {
            TripId = t.TripId,
            Name = t.Name,
            StartDate = t.StartDate,
            EndDate = t.EndDate
        };
        private static void Validate(TripUpsertDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Trip name is reguired.");
            if (dto.StartDate == default || dto.EndDate == default || dto.EndDate.Date < dto.StartDate.Date)
                throw new ArgumentException("Invalid trip date range.");
        }
        public async Task<List<TripDto>> MineAsync(string userId)
        {
           return (await _repo.ListMineAsync(userId)).Select(Map).ToList();
        }
       public async Task<TripDto?> GetMineAsync(int id,string userId)
        {
            var t = await _repo.GetMineAsync(id, userId);
            return t is null ? null : Map(t);
        }
        public async Task<TripDto> CreateAsync(string userId,TripUpsertDto dto)
        {
            Validate(dto);
            var t = new Trip
            {
                UserId = userId,
                Name = dto.Name.Trim(),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
            await _repo.AddAsync(t);
            await _repo.SaveAsync();
            return Map(t);
        }
        public async Task<TripDto?> UpdateAsync(int id,string userId,TripUpsertDto dto)
        {
            var t = await _repo.GetMineAsync(id, userId);
            if (t is null) return null;
            Validate(dto);
            t.Name = dto.Name.Trim();
            t.StartDate = dto.StartDate;
            t.EndDate = dto.EndDate;
            await _repo.SaveAsync();
            return Map(t);
        }
        public async Task<bool> DeleteMineAsync(int id,string userId)
        {
            var t = await _repo.GetMineAsync(id, userId);
            if (t is null) return false;
            _repo.Delete(t);
            await _repo.SaveAsync();
            return true;
        }
        public async Task<List<TripDto>> AllAsync()
        {
            var trips = await _repo.ListAllAsync();
             return trips.Select(Map).ToList();
        }
        public async Task<TripDto?> GetAnyAsync(int id)
        {
            var t = await _repo.GetAsync(id);
            return t is null ? null : Map(t);
        }
        public async Task<bool> DeleteAnyAsync(int id)
        {
            var t = await _repo.GetAsync(id);
            if (t is null) return false;
            _repo.Delete(t);
            await _repo.SaveAsync();
            return true;
        }
    }
}
