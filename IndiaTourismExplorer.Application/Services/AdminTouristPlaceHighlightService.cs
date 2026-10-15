using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;

namespace IndiaTourismExplorer.Application.Services;

public sealed class AdminTouristPlaceHighlightService
    : IAdminTouristPlaceHighlightService
{
    private readonly IAdminTouristPlaceHighlightRepository _repository;

    public AdminTouristPlaceHighlightService(
        IAdminTouristPlaceHighlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AdminTouristPlaceHighlightDto>>
        GetByTouristPlaceIdAsync(int touristPlaceId)
    {
        if (touristPlaceId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(touristPlaceId),
                "Tourist place ID must be greater than zero.");
        }

        var highlights = await _repository
            .GetByTouristPlaceIdAsync(touristPlaceId);

        return highlights.Select(MapToDto).ToList();
    }

    public async Task<AdminTouristPlaceHighlightDto?> GetByIdAsync(
        int highlightId)
    {
        if (highlightId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(highlightId),
                "Highlight ID must be greater than zero.");
        }

        var highlight = await _repository.GetByIdAsync(highlightId);

        return highlight is null ? null : MapToDto(highlight);
    }

    public async Task<AdminTouristPlaceHighlightDto?> CreateAsync(
        AdminTouristPlaceHighlightDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        ValidateDto(dto);

        var placeExists = await _repository
            .TouristPlaceExistsAsync(dto.TouristPlaceId);

        if (!placeExists)
        {
            return null;
        }

        var highlight = new TouristPlaceHighlight
        {
            TouristPlaceId = dto.TouristPlaceId,
            HighlightText = dto.HighlightText.Trim()
        };

        // Map other fields only when those properties exist in the real entity.
        await _repository.AddAsync(highlight);
        await _repository.SaveChangeAsync();

        return MapToDto(highlight);
    }

    public async Task<AdminTouristPlaceHighlightDto?> UpdateAsync(
        int highlightId,
        AdminTouristPlaceHighlightDto dto)
    {
        if (highlightId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(highlightId),
                "Highlight ID must be greater than zero.");
        }

        ArgumentNullException.ThrowIfNull(dto);
        ValidateDto(dto);

        var highlight = await _repository.GetByIdAsync(highlightId);

        if (highlight is null)
        {
            return null;
        }

        var placeExists = await _repository
            .TouristPlaceExistsAsync(dto.TouristPlaceId);

        if (!placeExists)
        {
            return null;
        }

        highlight.TouristPlaceId = dto.TouristPlaceId;
        highlight.HighlightText = dto.HighlightText.Trim();

        // Update only other fields that exist in both the DTO and entity.
        await _repository.SaveChangeAsync();

        return MapToDto(highlight);
    }

    public async Task<bool> DeleteAsync(int highlightId)
    {
        if (highlightId <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(highlightId),
                "Highlight ID must be greater than zero.");
        }

        var highlight = await _repository.GetByIdAsync(highlightId);

        if (highlight is null)
        {
            return false;
        }

        await _repository.DeleteAsync(highlight);
        await _repository.SaveChangeAsync();

        return true;
    }

    private static void ValidateDto(AdminTouristPlaceHighlightDto dto)
    {
        if (dto.TouristPlaceId <= 0)
        {
            throw new ArgumentException(
                "TouristPlaceId must be greater than zero.",
                nameof(dto));
        }

        if (string.IsNullOrWhiteSpace(dto.HighlightText))
        {
            throw new ArgumentException(
                "HighlightText is required.",
                nameof(dto));
        }

        // Replace 500 with the actual entity/database max length if one is configured.
        if (dto.HighlightText.Trim().Length > 500)
        {
            throw new ArgumentException(
                "HighlightText cannot exceed 500 characters.",
                nameof(dto));
        }
    }

    private static AdminTouristPlaceHighlightDto MapToDto(
        TouristPlaceHighlight entity)
    {
        return new AdminTouristPlaceHighlightDto
        {
            TouristPlaceHighlightId = entity.TouristPlaceHighlightId,
            TouristPlaceId = entity.TouristPlaceId,
            HighlightText = entity.HighlightText
        };
    }
}