using IndiaTourismExplorer.Application.DTOs;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IFavoriteService
{
    Task<bool> AddFavoriteAsync(string userId, int touristPlaceId);

    Task<bool> RemoveFavoriteAsync(string userId, int touristPlaceId);

    Task<bool> IsFavoriteAsync(string userId, int touristPlaceId);

    Task<List<FavoriteDto>> GetMyFavoritesAsync(string userId);
}