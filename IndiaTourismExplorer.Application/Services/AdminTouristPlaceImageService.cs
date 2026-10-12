using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Services
{
    public sealed class AdminTouristPlaceImageService : IAdminTouristPlaceImageService
    {
        private readonly IAdminTouristPlaceImageRepository _repository;
        public AdminTouristPlaceImageService(IAdminTouristPlaceImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<AdminTouristPlaceImageDto>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
            var images = await _repository.GetByTouristPlaceIdAsync(touristPlaceId);
            return images.Select(MapToDto).ToList();
        }
        public async Task<AdminTouristPlaceImageDto?> GetByIdAsync(int imageId)
        {
            var image = await _repository.GetByIdAsync(imageId);
            return image is null ? null : MapToDto(image);
        }
        public async Task<AdminTouristPlaceImageDto?> CreateAsync(AdminTouristPlaceImageDto request)
        {
            if (!await _repository.TouristPlaceExistsAsync(request.TouristPlaceId))
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(request.ImageUrl))
            {
                throw new ArgumentException("ImageUrl is required.", nameof(request));
            }
            var image = new TouristPlaceImage
            {
                TouristPlaceId = request.TouristPlaceId,
                ImageUrl = request.ImageUrl.Trim(),
                AltText = request.AltText?.Trim(),
                DisplayOrder = Math.Max(0, request.DisplayOrder),
                IsPrimary = request.IsPrimary
            };
            await _repository.AddAsync(image);
            await _repository.SaveChangesAsync();
            return MapToDto(image);
        }
        public async Task<bool> UpdateAsync(int imageId, AdminTouristPlaceImageDto request)
        {
            var image = await _repository.GetByIdAsync(imageId);
            if (image is null)
            {
                return false;
            }
            if (!await _repository.TouristPlaceExistsAsync(request.TouristPlaceId))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(request.ImageUrl))
            {
                throw new ArgumentException("ImageUrl is required.", nameof(request));
            }
            image.TouristPlaceId = request.TouristPlaceId;
            image.ImageUrl = request.ImageUrl.Trim();
            image.AltText = request.AltText?.Trim();
            image.DisplayOrder = Math.Max(0, request.DisplayOrder);
            image.IsPrimary = request.IsPrimary;
            await _repository.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int imageId)
        {
            var image = await _repository.GetByIdAsync(imageId);
            if (image is null)
            {
                return false;
            }
            await _repository.DeleteAsync(image);
            await _repository.SaveChangesAsync();
            return true;
        }

        private static AdminTouristPlaceImageDto MapToDto(TouristPlaceImage image)
        {
            return new AdminTouristPlaceImageDto
            {
                TouristPlaceImageId = image.ImageId,
                TouristPlaceId = image.TouristPlaceId,
                ImageUrl = image.ImageUrl,
                AltText = image.AltText,
                DisplayOrder = image.DisplayOrder,
                IsPrimary = image.IsPrimary
            };
        }
    }
}
