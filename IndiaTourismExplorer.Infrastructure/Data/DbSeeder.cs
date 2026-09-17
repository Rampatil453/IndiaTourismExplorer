using IndiaTourismExplorer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace IndiaTourismExplorer.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(
    TourismDbContext context,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration)
    {
        // Seed States
        if (!await context.States.AnyAsync())
        {
            var states = new List<State>
            {
                new State
                {
                    Name = "Maharashtra",
                    Code = "MH",
                    Description = "Maharashtra is known for forts, beaches, caves and historical places.",
                    ImageUrl = "/images/states/maharashtra.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new State
                {
                    Name = "Goa",
                    Code = "GA",
                    Description = "Goa is famous for beaches, churches, forts and natural attractions.",
                    ImageUrl = "/images/states/goa.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new State
                {
                    Name = "Rajasthan",
                    Code = "RJ",
                    Description = "Rajasthan is famous for forts, palaces and historical places.",
                    ImageUrl = "/images/states/rajasthan.jpg",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.States.AddRangeAsync(states);
            await context.SaveChangesAsync();
        }

        // Seed Locations
        if (!await context.Locations.AnyAsync())
        {
            var maharashtra = await context.States
                .FirstAsync(x => x.Code == "MH");

            var goa = await context.States
                .FirstAsync(x => x.Code == "GA");

            var rajasthan = await context.States
                .FirstAsync(x => x.Code == "RJ");

            var locations = new List<Location>
            {
                new Location
                {
                    StateId = maharashtra.StateId,
                    Name = "Pune",
                    Type = "City",
                    Description = "Pune is known for historical forts and cultural attractions.",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Location
                {
                    StateId = maharashtra.StateId,
                    Name = "Mumbai",
                    Type = "City",
                    Description = "Mumbai is a major city known for beaches and historical landmarks.",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Location
                {
                    StateId = goa.StateId,
                    Name = "North Goa",
                    Type = "District",
                    Description = "North Goa is popular for beaches, forts and nightlife.",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Location
                {
                    StateId = rajasthan.StateId,
                    Name = "Jaipur",
                    Type = "City",
                    Description = "Jaipur is famous for forts, palaces and historical architecture.",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Locations.AddRangeAsync(locations);
            await context.SaveChangesAsync();
        }

        // Seed Categories
        if (!await context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Fort",
                    Description = "Historic forts and fortifications.",
                    Icon = "fort",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Category
                {
                    Name = "Beach",
                    Description = "Popular beaches and coastal destinations.",
                    Icon = "beach",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Category
                {
                    Name = "Temple",
                    Description = "Temples and religious attractions.",
                    Icon = "temple",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Category
                {
                    Name = "Historical",
                    Description = "Historical monuments and heritage places.",
                    Icon = "history",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Category
                {
                    Name = "Trekking",
                    Description = "Trekking and adventure destinations.",
                    Icon = "trekking",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new Category
                {
                    Name = "Museum",
                    Description = "Museums and cultural attractions.",
                    Icon = "museum",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }

        // Seed Tourist Places
        if (!await context.TouristPlaces.AnyAsync())
        {
            var pune = await context.Locations
                .FirstAsync(x => x.Name == "Pune");

            var mumbai = await context.Locations
                .FirstAsync(x => x.Name == "Mumbai");

            var northGoa = await context.Locations
                .FirstAsync(x => x.Name == "North Goa");

            var jaipur = await context.Locations
                .FirstAsync(x => x.Name == "Jaipur");

            var touristPlaces = new List<TouristPlace>
            {
                new TouristPlace
                {
                    LocationId = pune.LocationId,
                    Name = "Sinhagad Fort",
                    ShortDescription = "A historic hill fort near Pune.",
                    Description = "Sinhagad Fort is a popular historical and trekking destination near Pune.",
                    Address = "Sinhagad, Pune, Maharashtra",
                    Latitude = 18.3663m,
                    Longitude = 73.7559m,
                    IsFeatured = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new TouristPlace
                {
                    LocationId = mumbai.LocationId,
                    Name = "Gateway of India",
                    ShortDescription = "A famous historical monument in Mumbai.",
                    Description = "The Gateway of India is one of Mumbai's most famous landmarks.",
                    Address = "Apollo Bandar, Mumbai, Maharashtra",
                    Latitude = 18.9220m,
                    Longitude = 72.8347m,
                    IsFeatured = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new TouristPlace
                {
                    LocationId = northGoa.LocationId,
                    Name = "Baga Beach",
                    ShortDescription = "One of the most popular beaches in Goa.",
                    Description = "Baga Beach is known for its scenic coastline and vibrant tourist atmosphere.",
                    Address = "Baga, North Goa, Goa",
                    Latitude = 15.5557m,
                    Longitude = 73.7517m,
                    IsFeatured = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },

                new TouristPlace
                {
                    LocationId = jaipur.LocationId,
                    Name = "Amber Fort",
                    ShortDescription = "A magnificent historic fort near Jaipur.",
                    Description = "Amber Fort is a famous historical fort known for its architecture and heritage.",
                    Address = "Amer, Jaipur, Rajasthan",
                    Latitude = 26.9855m,
                    Longitude = 75.8513m,
                    IsFeatured = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.TouristPlaces.AddRangeAsync(touristPlaces);
            await context.SaveChangesAsync();
        }

        // Seed Tourist Place Categories
        if (!await context.TouristPlaceCategories.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var fort = await context.Categories
                .FirstAsync(x => x.Name == "Fort");

            var beach = await context.Categories
                .FirstAsync(x => x.Name == "Beach");

            var historical = await context.Categories
                .FirstAsync(x => x.Name == "Historical");

            var trekking = await context.Categories
                .FirstAsync(x => x.Name == "Trekking");

            var mappings = new List<TouristPlaceCategory>
            {
                new TouristPlaceCategory
                {
                    TouristPlaceId = sinhagad.TouristPlaceId,
                    CategoryId = fort.CategoryId
                },

                new TouristPlaceCategory
                {
                    TouristPlaceId = sinhagad.TouristPlaceId,
                    CategoryId = trekking.CategoryId
                },

                new TouristPlaceCategory
                {
                    TouristPlaceId = gateway.TouristPlaceId,
                    CategoryId = historical.CategoryId
                },

                new TouristPlaceCategory
                {
                    TouristPlaceId = baga.TouristPlaceId,
                    CategoryId = beach.CategoryId
                },

                new TouristPlaceCategory
                {
                    TouristPlaceId = amber.TouristPlaceId,
                    CategoryId = fort.CategoryId
                },

                new TouristPlaceCategory
                {
                    TouristPlaceId = amber.TouristPlaceId,
                    CategoryId = historical.CategoryId
                }
            };

            await context.TouristPlaceCategories.AddRangeAsync(mappings);
            await context.SaveChangesAsync();
        }
        // Seed Tourist Place Images
        if (!await context.TouristPlaceImages.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var images = new List<TouristPlaceImage>
    {
        new TouristPlaceImage
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            ImageUrl = "/images/places/sinhagad-fort-1.jpg",
            AltText = "Sinhagad Fort view",
            IsPrimary = true,
            DisplayOrder = 1,
            CreatedAt = DateTime.UtcNow
        },

        new TouristPlaceImage
        {
            TouristPlaceId = gateway.TouristPlaceId,
            ImageUrl = "/images/places/gateway-of-india-1.jpg",
            AltText = "Gateway of India",
            IsPrimary = true,
            DisplayOrder = 1,
            CreatedAt = DateTime.UtcNow
        },

        new TouristPlaceImage
        {
            TouristPlaceId = baga.TouristPlaceId,
            ImageUrl = "/images/places/baga-beach-1.jpg",
            AltText = "Baga Beach",
            IsPrimary = true,
            DisplayOrder = 1,
            CreatedAt = DateTime.UtcNow
        },

        new TouristPlaceImage
        {
            TouristPlaceId = amber.TouristPlaceId,
            ImageUrl = "/images/places/amber-fort-1.jpg",
            AltText = "Amber Fort",
            IsPrimary = true,
            DisplayOrder = 1,
            CreatedAt = DateTime.UtcNow
        }
    };

            await context.TouristPlaceImages.AddRangeAsync(images);
            await context.SaveChangesAsync();
        }
        // Seed Tourist Place Highlights
        if (!await context.TouristPlaceHighlights.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var highlights = new List<TouristPlaceHighlight>
    {
        new TouristPlaceHighlight
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            Title = "Historic Hill Fort",
            Description = "A historic fort located on a hill near Pune.",
            DisplayOrder = 1
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            Title = "Popular Trek",
            Description = "A popular trekking destination offering scenic views.",
            DisplayOrder = 2
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = gateway.TouristPlaceId,
            Title = "Iconic Landmark",
            Description = "One of Mumbai's most recognized historical landmarks.",
            DisplayOrder = 1
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = gateway.TouristPlaceId,
            Title = "Waterfront Location",
            Description = "Located near the Arabian Sea at Apollo Bandar.",
            DisplayOrder = 2
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = baga.TouristPlaceId,
            Title = "Popular Beach",
            Description = "A popular beach destination in North Goa.",
            DisplayOrder = 1
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = baga.TouristPlaceId,
            Title = "Scenic Coastline",
            Description = "Known for its scenic coastline and lively tourist atmosphere.",
            DisplayOrder = 2
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = amber.TouristPlaceId,
            Title = "Historic Architecture",
            Description = "A magnificent fort known for its architecture and heritage.",
            DisplayOrder = 1
        },

        new TouristPlaceHighlight
        {
            TouristPlaceId = amber.TouristPlaceId,
            Title = "Royal Heritage",
            Description = "An important historical attraction near Jaipur.",
            DisplayOrder = 2
        }
    };

            await context.TouristPlaceHighlights.AddRangeAsync(highlights);
            await context.SaveChangesAsync();
        }
        // Seed Visiting Information
        if (!await context.VisitingInformations.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var visitingInformation = new List<VisitingInformation>
    {
        new VisitingInformation
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            BestTimeToVisit = "October to February",
            OpeningTime = new TimeSpan(6, 0, 0),
            ClosingTime = new TimeSpan(18, 0, 0),
            EntryFee = 20,
            RecommendedDurationMinutes = 180,
            BookingRequired = false,
            AdditionalInformation = "Carry water and suitable footwear for trekking."
        },

        new VisitingInformation
        {
            TouristPlaceId = gateway.TouristPlaceId,
            BestTimeToVisit = "November to February",
            OpeningTime = new TimeSpan(0, 0, 0),
            ClosingTime = new TimeSpan(23, 59, 0),
            EntryFee = 0,
            RecommendedDurationMinutes = 90,
            BookingRequired = false,
            AdditionalInformation = "The surrounding area can be busy during peak tourist hours."
        },

        new VisitingInformation
        {
            TouristPlaceId = baga.TouristPlaceId,
            BestTimeToVisit = "November to February",
            OpeningTime = new TimeSpan(0, 0, 0),
            ClosingTime = new TimeSpan(23, 59, 0),
            EntryFee = 0,
            RecommendedDurationMinutes = 180,
            BookingRequired = false,
            AdditionalInformation = "Evening is a popular time to visit the beach."
        },

        new VisitingInformation
        {
            TouristPlaceId = amber.TouristPlaceId,
            BestTimeToVisit = "October to March",
            OpeningTime = new TimeSpan(8, 0, 0),
            ClosingTime = new TimeSpan(18, 0, 0),
            EntryFee = 100,
            RecommendedDurationMinutes = 180,
            BookingRequired = false,
            AdditionalInformation = "Comfortable footwear is recommended for exploring the fort."
        }
    };

            await context.VisitingInformations.AddRangeAsync(visitingInformation);
            await context.SaveChangesAsync();
        }
        // Seed Travel Options
        if (!await context.TravelOptions.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var travelOptions = new List<TravelOption>
    {
        new TravelOption
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            TransportType = "Car",
            Title = "Drive from Pune",
            Description = "Drive towards Sinhagad and continue to the fort entrance."
        },

        new TravelOption
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            TransportType = "Bus",
            Title = "Bus from Pune",
            Description = "Take a bus towards Sinhagad and continue to the fort."
        },

        new TravelOption
        {
            TouristPlaceId = gateway.TouristPlaceId,
            TransportType = "Train",
            Title = "Train to Churchgate",
            Description = "Travel by local train to Churchgate and continue towards Colaba."
        },

        new TravelOption
        {
            TouristPlaceId = gateway.TouristPlaceId,
            TransportType = "Taxi",
            Title = "Taxi from Mumbai",
            Description = "Take a taxi directly to Apollo Bandar."
        },

        new TravelOption
        {
            TouristPlaceId = baga.TouristPlaceId,
            TransportType = "Taxi",
            Title = "Taxi from Goa",
            Description = "Take a taxi from nearby areas of Goa to Baga Beach."
        },

        new TravelOption
        {
            TouristPlaceId = baga.TouristPlaceId,
            TransportType = "Bus",
            Title = "Bus to Baga",
            Description = "Use local bus services towards the Baga area."
        },

        new TravelOption
        {
            TouristPlaceId = amber.TouristPlaceId,
            TransportType = "Car",
            Title = "Drive from Jaipur",
            Description = "Drive from Jaipur towards Amer and Amber Fort."
        },

        new TravelOption
        {
            TouristPlaceId = amber.TouristPlaceId,
            TransportType = "Taxi",
            Title = "Taxi from Jaipur",
            Description = "Take a taxi directly from Jaipur to Amber Fort."
        }
    };

            await context.TravelOptions.AddRangeAsync(travelOptions);
            await context.SaveChangesAsync();
        }
        // Seed Nearby Places
        if (!await context.NearbyPlaces.AnyAsync())
        {
            var sinhagad = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Sinhagad Fort");

            var gateway = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Gateway of India");

            var baga = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Baga Beach");

            var amber = await context.TouristPlaces
                .FirstAsync(x => x.Name == "Amber Fort");

            var nearbyPlaces = new List<NearbyPlace>
    {
        new NearbyPlace
        {
            TouristPlaceId = sinhagad.TouristPlaceId,
            NearbyTouristPlaceId = gateway.TouristPlaceId,
            DistanceKm = 150,
            Description = "Gateway of India is a major attraction in Mumbai."
        },

        new NearbyPlace
        {
            TouristPlaceId = gateway.TouristPlaceId,
            NearbyTouristPlaceId = sinhagad.TouristPlaceId,
            DistanceKm = 150,
            Description = "Sinhagad Fort is a popular historical attraction near Pune."
        },

        new NearbyPlace
        {
            TouristPlaceId = baga.TouristPlaceId,
            NearbyTouristPlaceId = amber.TouristPlaceId,
            DistanceKm = 1600,
            Description = "Amber Fort is a major historical attraction in Rajasthan."
        },

        new NearbyPlace
        {
            TouristPlaceId = amber.TouristPlaceId,
            NearbyTouristPlaceId = baga.TouristPlaceId,
            DistanceKm = 1600,
            Description = "Baga Beach is a popular coastal destination in Goa."
        }
    };

            await context.NearbyPlaces.AddRangeAsync(nearbyPlaces);
            await context.SaveChangesAsync();
        }
        // Seed Admin Role and Admin User
        // Seed Admin Role and Admin User

        const string adminRole = "Admin";

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            var roleResult = await roleManager.CreateAsync(
                new IdentityRole(adminRole));

            if (!roleResult.Succeeded)
            {
                throw new Exception(
                    "Failed to create Admin role: " +
                    string.Join(", ",
                        roleResult.Errors.Select(x => x.Description)));
            }
        }

        var adminEmail = configuration["AdminSeed:Email"];
        var adminPassword = configuration["AdminSeed:Password"];

        if (string.IsNullOrWhiteSpace(adminEmail) ||
            string.IsNullOrWhiteSpace(adminPassword))
        {
            throw new InvalidOperationException(
                "AdminSeed:Email and AdminSeed:Password must be configured.");
        }

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "System Administrator",
                CreatedAt = DateTime.UtcNow
            };

            var userResult = await userManager.CreateAsync(
                adminUser,
                adminPassword);

            if (!userResult.Succeeded)
            {
                throw new Exception(
                    "Failed to create Admin user: " +
                    string.Join(", ",
                        userResult.Errors.Select(x => x.Description)));
            }
        }

        if (!await userManager.IsInRoleAsync(adminUser, adminRole))
        {
            var roleResult = await userManager.AddToRoleAsync(
                adminUser,
                adminRole);

            if (!roleResult.Succeeded)
            {
                throw new Exception(
                    "Failed to assign Admin role: " +
                    string.Join(", ",
                        roleResult.Errors.Select(x => x.Description)));
            }
        }
    }

}