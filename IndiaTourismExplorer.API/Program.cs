using IndiaTourismExplorer.Application.Interfaces;
using IndiaTourismExplorer.Application.Services;
using IndiaTourismExplorer.Domain.Entities;
using IndiaTourismExplorer.Infrastructure.Data;
using IndiaTourismExplorer.Infrastructure.Repositories;
using IndiaTourismExplorer.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =====================================================
// Add Controllers
// =====================================================

builder.Services.AddControllers();


// =====================================================
// CORS
// =====================================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// =====================================================
// Database
// =====================================================

builder.Services.AddDbContext<TourismDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// =====================================================
// ASP.NET Core Identity
// =====================================================

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<TourismDbContext>()
    .AddDefaultTokenProviders();


// =====================================================
// JWT Authentication
// =====================================================

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]!
            ))
    };
});


// =====================================================
// Dependency Injection - State
// =====================================================

builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();


// =====================================================
// Dependency Injection - Location
// =====================================================

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();


// =====================================================
// Dependency Injection - Tourist Place
// =====================================================

builder.Services.AddScoped<
    ITouristPlaceRepository,
    TouristPlaceRepository>();

builder.Services.AddScoped<
    ITouristPlaceService,
    TouristPlaceService>();


// =====================================================
// Dependency Injection - Category
// =====================================================

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


// =====================================================
// Dependency Injection - Authentication
// =====================================================

builder.Services.AddScoped<IAuthService, AuthService>();


// =====================================================
// Dependency Injection - Favorites
// =====================================================

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();


// =====================================================
// Dependency Injection - Reviews
// =====================================================

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();


// =====================================================
// Swagger
// =====================================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // JWT Bearer definition
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter your JWT token."
        });


    // JWT security requirement
    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference(
                "Bearer",
                document)] = []
        });
});


// =====================================================
// Build Application
// =====================================================

var app = builder.Build();


// =====================================================
// Database Seeder
// =====================================================

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<TourismDbContext>();

    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<ApplicationUser>>();

    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    await DbSeeder.SeedAsync(
        context,
        userManager,
        roleManager,
        builder.Configuration);
}


// =====================================================
// Swagger Middleware
// =====================================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "IndiaTourismExplorer API v1");
    });
}


// =====================================================
// HTTP Request Pipeline
// =====================================================

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


// =====================================================
// Run Application
// =====================================================

app.Run();