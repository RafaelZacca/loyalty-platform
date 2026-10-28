using Microsoft.EntityFrameworkCore;

namespace LoyaltyPlatform.Api.Persistence;

// Intentionally empty: no entities are defined until business tasks are approved.
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options);
