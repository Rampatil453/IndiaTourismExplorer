using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface IFavoriteRepository
{
    Task<Favorite?> GetByUserAndPlaceAsync(
        string userId,
        int touristPlaceId);

    Task<List<Favorite>> GetByUserIdAsync(
        string userId);

    Task AddAsync(Favorite favorite);

    void Remove(Favorite favorite);

    Task SaveChangesAsync();
}