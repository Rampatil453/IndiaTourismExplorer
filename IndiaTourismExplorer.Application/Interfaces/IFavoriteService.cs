using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IFavoriteService
{
    Task<bool> AddFavoriteAsync(string userId, int touristPlaceId);

    Task<bool> RemoveFavoriteAsync(string userId, int touristPlaceId);

    Task<bool> IsFavoriteAsync(string userId, int touristPlaceId);

    Task<List<FavoriteDto>> GetMyFavoritesAsync(string userId);
    Task<List<int>> GetMineIdsAsync(string userId);
    Task<bool> ExistsAsync(string userId, int placeId);
    Task<bool> AddMineAsync(string userId, int placeId);
    Task<bool> RemoveMineAsync(string userId, int placeId);
    Task<List<FavoriteSummaryDto>> GetSummaryAsync();
}