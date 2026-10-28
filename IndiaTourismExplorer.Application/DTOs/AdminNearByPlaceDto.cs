using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndiaTourismExplorer.Application.DTOs
{
    public sealed class AdminNearbyPlaceDto
    {
        public int NearbyPlaceId { get; set; }
        public int TouristPlaceId { get; set; }
        public int NearbyTouristPlaceId { get; set; }

    }
    public sealed class CreateNearbyPlaceDto
    {
        [Range(1, int.MaxValue)] public int TouristPlaceId { get; set; }
        [Range(1,int.MaxValue)] public int NearbyTouristPlaceId { get; set; }
    }
}
