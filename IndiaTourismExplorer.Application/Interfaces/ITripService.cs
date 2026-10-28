using IndiaTourismExplorer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Interfaces
{
    public interface ITripService
    {
        Task<List<TripDto>> MineAsync(string userId);
        Task<TripDto?> GetMineAsync(int id, string userId);
        Task<TripDto> CreateAsync(string userId, TripUpsertDto dto);
        Task<TripDto?> UpdateAsync(int id, string userId, TripUpsertDto dto);
        Task<bool> DeleteMineAsync(int id, string userId);
        Task<List<TripDto>> AllAsync();
        Task<TripDto?> GetAnyAsync(int id);
        Task<bool> DeleteAnyAsync(int id);
    }
}
