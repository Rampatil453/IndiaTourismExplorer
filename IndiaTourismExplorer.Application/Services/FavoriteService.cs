using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _repository;

    public FavoriteService(IFavoriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddFavoriteAsync(
        string userId,
        int touristPlaceId)
    {
        var existingFavorite =
            await _repository.GetByUserAndPlaceAsync(
                userId,
                touristPlaceId);

        if (existingFavorite != null)
        {
            return false;
        }

        var favorite = new Favorite
        {
            UserId = userId,
            TouristPlaceId = touristPlaceId,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(favorite);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveFavoriteAsync(
        string userId,
        int touristPlaceId)
    {
        var favorite =
            await _repository.GetByUserAndPlaceAsync(
                userId,
                touristPlaceId);

        if (favorite == null)
        {
            return false;
        }

        _repository.Remove(favorite);
        await _repository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> IsFavoriteAsync(
    string userId,
    int touristPlaceId)
    {
        var favorite =
            await _repository.GetByUserAndPlaceAsync(
                userId,
                touristPlaceId);

        return favorite != null;
    }

    public async Task<List<FavoriteDto>> GetMyFavoritesAsync(
        string userId)
    {
        var favorites =
            await _repository.GetByUserIdAsync(userId);

        return favorites.Select(x => new FavoriteDto
        {
            FavoriteId = x.FavoriteId,
            TouristPlaceId = x.TouristPlaceId,
            TouristPlaceName = x.TouristPlace.Name,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
}