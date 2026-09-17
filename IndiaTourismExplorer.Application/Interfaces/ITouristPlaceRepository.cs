using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Interfaces;

public interface ITouristPlaceRepository
{
    Task<List<TouristPlace>> GetByLocationIdAsync(int locationId);


    Task<TouristPlace?> GetByIdAsync(int id);

    Task<List<TouristPlace>> GetFeaturedAsync();

    Task<TouristPlace?> GetDetailsByIdAsync(int id);

    Task<List<TouristPlace>> GetByCategoryIdAsync(int categoryId);

    Task<TouristPlace?> GetByIdAsync(int id);

    Task AddAsync(TouristPlace touristPlace);

    void Update(TouristPlace touristPlace);

    void Remove(TouristPlace touristPlace);

    Task SaveChangesAsync();
}