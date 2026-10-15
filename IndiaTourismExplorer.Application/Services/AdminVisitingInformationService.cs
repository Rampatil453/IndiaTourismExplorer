using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services;

public sealed class AdminVisitingInformationService
    : IAdminVisitingInformationService
{
    private readonly IAdminVisitingInformationRepository _repository;

    public AdminVisitingInformationService(
        IAdminVisitingInformationRepository repository)
    {
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<List<AdminVisitingInformationDto>>
        GetByTouristPlaceIdAsync(int touristPlaceId)
    {
        ValidateId(touristPlaceId, nameof(touristPlaceId));

        if (!await _repository.TouristPlaceExistsAsync(touristPlaceId))
            throw new KeyNotFoundException("Tourist place was not found.");

        var entities =
            await _repository.GetByTouristPlaceIdAsync(touristPlaceId);

        return entities.Select(ToDto).ToList();
    }

    public async Task<AdminVisitingInformationDto?> GetByIdAsync(int id)
    {
        ValidateId(id, nameof(id));

        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : ToDto(entity);
    }

    public async Task<AdminVisitingInformationDto> CreateAsync(
        AdminVisitingInformationDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        ValidateDto(dto);

        if (!await _repository.TouristPlaceExistsAsync(dto.TouristPlaceId))
            throw new ArgumentException(
                "The specified tourist place does not exist.",
                nameof(dto.TouristPlaceId));

        // The entity is one-to-one with TouristPlace. Add a repository
        // method such as ExistsByTouristPlaceIdAsync if the current repository
        // does not already provide a safe duplicate check.
        var entity = ToNewEntity(dto);
        var saved = await _repository.AddAsync(entity);

        // AddAsync must SaveChangesAsync before returning the entity.
        return ToDto(saved);
    }

    public async Task<bool> UpdateAsync(
        int id,
        AdminVisitingInformationDto dto)
    {
        ValidateId(id, nameof(id));
        ArgumentNullException.ThrowIfNull(dto);
        ValidateDto(dto);

        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return false;

        if (!await _repository.TouristPlaceExistsAsync(dto.TouristPlaceId))
            throw new ArgumentException(
                "The specified tourist place does not exist.",
                nameof(dto.TouristPlaceId));

        // Keep the existing primary key. Map only editable scalar fields.
        ApplyEditableFields(existing, dto);

        await _repository.UpdateAsync(existing);
        return true;
    }

    public Task<bool> DeleteAsync(int id)
    {
        ValidateId(id, nameof(id));
        return _repository.DeleteAsync(id);
    }

    private static void ValidateId(int id, string parameterName)
    {
        if (id <= 0)
            throw new ArgumentException(
                "ID must be greater than zero.", parameterName);
    }

    private static void ValidateDto(AdminVisitingInformationDto dto)
    {
        if (dto.TouristPlaceId <= 0)
            throw new ArgumentException(
                "TouristPlaceId must be greater than zero.",
                nameof(dto.TouristPlaceId));

        if (dto.EntryFee is < 0)
            throw new ArgumentException(
                "EntryFee cannot be negative.", nameof(dto.EntryFee));

        if (dto.RecommendedDurationMinutes is <= 0)
            throw new ArgumentException(
                "RecommendedDurationMinutes must be greater than zero.",
                nameof(dto.RecommendedDurationMinutes));

        if (dto.BookingRequired &&
            string.IsNullOrWhiteSpace(dto.BookingUrl))
        {
            throw new ArgumentException(
                "BookingUrl is required when BookingRequired is true.",
                nameof(dto.BookingUrl));
        }

        if (!string.IsNullOrWhiteSpace(dto.BookingUrl) &&
            !Uri.TryCreate(dto.BookingUrl, UriKind.Absolute, out var uri))
        {
            throw new ArgumentException(
                "BookingUrl must be an absolute URL.",
                nameof(dto.BookingUrl));
        }
        else if (!string.IsNullOrWhiteSpace(dto.BookingUrl) &&
                 Uri.TryCreate(dto.BookingUrl, UriKind.Absolute, out uri) &&
                 uri.Scheme != Uri.UriSchemeHttp &&
                 uri.Scheme != Uri.UriSchemeHttps)
        {
            throw new ArgumentException(
                "BookingUrl must use HTTP or HTTPS.",
                nameof(dto.BookingUrl));
        }
    }

    private static VisitingInformation ToNewEntity(
        AdminVisitingInformationDto dto)
    {
        return new VisitingInformation
        {
            // Do not assign VisitingInformationId; the database generates it.
            TouristPlaceId = dto.TouristPlaceId,
            BestTimeToVisit = dto.BestTimeToVisit,
            OpeningTime = dto.OpeningTime,
            ClosingTime = dto.ClosingTime,
            EntryFee = dto.EntryFee,
            RecommendedDurationMinutes = dto.RecommendedDurationMinutes,
            AgeRestriction = dto.AgeRestriction,
            BookingRequired = dto.BookingRequired,
            BookingUrl = dto.BookingUrl,
            AdditionalInformation = dto.AdditionalInformation
        };
    }

    private static void ApplyEditableFields(
        VisitingInformation entity,
        AdminVisitingInformationDto dto)
    {
        entity.TouristPlaceId = dto.TouristPlaceId;
        entity.BestTimeToVisit = dto.BestTimeToVisit;
        entity.OpeningTime = dto.OpeningTime;
        entity.ClosingTime = dto.ClosingTime;
        entity.EntryFee = dto.EntryFee;
        entity.RecommendedDurationMinutes = dto.RecommendedDurationMinutes;
        entity.AgeRestriction = dto.AgeRestriction;
        entity.BookingRequired = dto.BookingRequired;
        entity.BookingUrl = dto.BookingUrl;
        entity.AdditionalInformation = dto.AdditionalInformation;
    }

    private static AdminVisitingInformationDto ToDto(
        VisitingInformation entity)
    {
        return new AdminVisitingInformationDto
        {
            VisitingInformationId = entity.VisitingInformationId,
            TouristPlaceId = entity.TouristPlaceId,
            BestTimeToVisit = entity.BestTimeToVisit,
            OpeningTime = entity.OpeningTime,
            ClosingTime = entity.ClosingTime,
            EntryFee = entity.EntryFee,
            RecommendedDurationMinutes =
                entity.RecommendedDurationMinutes,
            AgeRestriction = entity.AgeRestriction,
            BookingRequired = entity.BookingRequired,
            BookingUrl = entity.BookingUrl,
            AdditionalInformation = entity.AdditionalInformation
        };
    }

   
}