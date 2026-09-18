using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;

namespace IndiaTourismExplorer.Application.Services;

public class TouristPlaceService : ITouristPlaceService
{
    private readonly ITouristPlaceRepository _repository;

    public TouristPlaceService(
        ITouristPlaceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TouristPlaceDto>> GetByLocationIdAsync(
        int locationId)
    {
        var places = await _repository
            .GetByLocationIdAsync(locationId);

        return places.Select(MapToDto).ToList();
    }

    public async Task<TouristPlaceDto?> GetByIdAsync(int id)
    {
        var place = await _repository.GetByIdAsync(id);

        if (place == null)
        {
            return null;
        }

        return MapToDto(place);
    }
    public async Task<List<TouristPlaceDto>> GetByCategoryIdAsync(int categoryId)
    {
        var places = await _repository.GetByCategoryIdAsync(categoryId);

        return places.Select(MapToDto).ToList();
    }
    public async Task<TouristPlaceDetailsDto?> GetDetailsByIdAsync(int id)
    {
        var place = await _repository.GetDetailsByIdAsync(id);

        if (place == null)
            return null;

        return new TouristPlaceDetailsDto
        {
            TouristPlaceId = place.TouristPlaceId,
            LocationId = place.LocationId,
            Name = place.Name,
            ShortDescription = place.ShortDescription,
            Description = place.Description,
            Address = place.Address,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            IsFeatured = place.IsFeatured,

            Categories = place.TouristPlaceCategories
                .Select(x => x.Category.Name)
                .ToList(),

            Images = place.Images
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new TouristPlaceImageDto
                {
                    ImageId = x.ImageId,
                    ImageUrl = x.ImageUrl,
                    AltText = x.AltText,
                    IsPrimary = x.IsPrimary,
                    DisplayOrder = x.DisplayOrder
                })
                .ToList(),

            Highlights = place.Highlights
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new TouristPlaceHighlightDto
                {
                    HighlightId = x.HighlightId,
                    Title = x.Title,
                    Description = x.Description,
                    DisplayOrder = x.DisplayOrder
                })
                .ToList(),

            VisitingInformation = place.VisitingInformation == null
                ? null
                : new VisitingInformationDto
                {
                    BestTimeToVisit = place.VisitingInformation.BestTimeToVisit,
                    OpeningTime = place.VisitingInformation.OpeningTime,
                    ClosingTime = place.VisitingInformation.ClosingTime,
                    EntryFee = place.VisitingInformation.EntryFee,
                    RecommendedDurationMinutes =
                        place.VisitingInformation.RecommendedDurationMinutes,
                    AgeRestriction = place.VisitingInformation.AgeRestriction,
                    BookingRequired = place.VisitingInformation.BookingRequired,
                    BookingUrl = place.VisitingInformation.BookingUrl,
                    AdditionalInformation =
                        place.VisitingInformation.AdditionalInformation
                },

            TravelOptions = place.TravelOptions
                .Select(x => new TravelOptionDto
                {
                    TravelOptionId = x.TravelOptionId,
                    TransportType = x.TransportType,
                    Title = x.Title,
                    Description = x.Description
                })
                .ToList(),

            NearbyPlaces = place.NearbyPlaces
                .Select(x => new NearbyPlaceDto
                {
                    NearbyPlaceId = x.NearbyPlaceId,
                    TouristPlaceId = x.NearbyTouristPlaceId,
                    Name = x.NearbyTouristPlace.Name,
                    DistanceKm = x.DistanceKm,
                    Description = x.Description
                })
                .ToList()
        };
    }
    public async Task<List<TouristPlaceDto>> GetFeaturedAsync()
    {
        var places = await _repository.GetFeaturedAsync();

        return places.Select(place => new TouristPlaceDto
        {
            TouristPlaceId = place.TouristPlaceId,
            LocationId = place.LocationId,
            Name = place.Name,
            ShortDescription = place.ShortDescription,
            Description = place.Description,
            Address = place.Address,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            IsFeatured = place.IsFeatured,

            Categories = place.TouristPlaceCategories
                .Select(x => x.Category.Name)
                .ToList()
        }).ToList();
    }

    private static TouristPlaceDto MapToDto(
        Domain.Entities.TouristPlace place)
    {
        return new TouristPlaceDto
        {
            TouristPlaceId = place.TouristPlaceId,
            LocationId = place.LocationId,
            Name = place.Name,
            ShortDescription = place.ShortDescription,
            Description = place.Description,
            Address = place.Address,
            Latitude = place.Latitude,
            Longitude = place.Longitude,
            IsFeatured = place.IsFeatured,

            Categories = place.TouristPlaceCategories
                .Select(x => x.Category.Name)
                .ToList()
        };
    }
    public async Task<bool> CreateAsync(AdminTouristPlaceDto dto)
    {
        var touristPlace = new Domain.Entities.TouristPlace
        {
            Name = dto.Name,
            ShortDescription = dto.ShortDescription,
            Description = dto.Description,
            LocationId = dto.LocationId,
            Address = dto.Address,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude,
            IsFeatured = dto.IsFeatured,
            IsActive = dto.IsActive
        };

        await _repository.AddAsync(touristPlace);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(
        int id,
        AdminTouristPlaceDto dto)
    {
        var touristPlace = await _repository.GetByIdAsync(id);

        if (touristPlace == null)
        {
            return false;
        }

        touristPlace.Name = dto.Name;
        touristPlace.ShortDescription = dto.ShortDescription;
        touristPlace.Description = dto.Description;
        touristPlace.LocationId = dto.LocationId;
        touristPlace.Address = dto.Address;
        touristPlace.Latitude = dto.Latitude;
        touristPlace.Longitude = dto.Longitude;
        touristPlace.IsFeatured = dto.IsFeatured;
        touristPlace.IsActive = dto.IsActive;

        _repository.Update(touristPlace);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var touristPlace = await _repository.GetByIdAsync(id);

        if (touristPlace == null)
        {
            return false;
        }

        _repository.Remove(touristPlace);
        await _repository.SaveChangesAsync();

        return true;
    }
}