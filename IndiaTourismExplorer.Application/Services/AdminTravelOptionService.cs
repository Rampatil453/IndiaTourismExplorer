using IndiaTourismExplorer.Application.DTOs;
using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndiaTourismExplorer.Application.Services
{
    public sealed class AdminTravelOptionService : IAdminTravelOptionService
    {
        private readonly IAdminTravelOptionRepository _repository;
        public AdminTravelOptionService(IAdminTravelOptionRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<AdminTravelOptionDto>> GetByTouristPlaceIdAsync(int touristPlaceId)
        {
            if (!await _repository.TouristPlaceExistsAsync(touristPlaceId))
                throw new KeyNotFoundException("Tourist Place was not found.");
            var entities = await _repository.GetByTouristPlaceIdAsync(touristPlaceId);
            return entities.Select(ToDto).ToList();
        }
        public async Task<AdminTravelOptionDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : ToDto(entity);
        }
        public async Task<AdminTravelOptionDto> CreateAsync(AdminTravelOptionDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (!await _repository.TouristPlaceExistsAsync(dto.TouristPlaceId))
                throw new ArgumentException("the specified tourist place does not exist.", nameof(dto));
            var entity = ToEntity(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return ToDto(entity);
        }
        public async Task<AdminTravelOptionDto> UpdateAsync(int id, AdminTravelOptionDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return null;
            if (!await _repository.TouristPlaceExistsAsync(dto.TouristPlaceId))
                throw new ArgumentException("The specified tourist place does not exist.", nameof(dto));
            CopyScalarProperties(dto, entity);
            entity.TravelOptionId = id;
            _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return ToDto(entity);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;
            _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
        private static AdminTravelOptionDto ToDto(TravelOption entity)
        {
            var dto = new AdminTravelOptionDto();
            CopyScalarProperties(entity, dto);
            return dto;
        }
        private static TravelOption ToEntity(AdminTravelOptionDto dto)
        {
            var entity = new TravelOption();
            CopyScalarProperties(dto, entity);
            entity.TravelOptionId = 0;
            return entity;
        }
        private static void CopyScalarProperties(object source, object target)
        {
            var targetType = target.GetType();
            foreach (var property in source.GetType().GetProperties()
                         .Where(p => p.CanRead && p.CanWrite))
            {
                var targetProperty = targetType.GetProperty(property.Name);
                if (targetProperty is null || !targetProperty.CanWrite) continue;
                if (property.Name == nameof(TravelOption.TravelOptionId)) continue;
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string)) continue;
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)) { }
                if (targetProperty.PropertyType == property.PropertyType)
                    targetProperty.SetValue(target, property.GetValue(source));
            }
        }
    }
    
}
