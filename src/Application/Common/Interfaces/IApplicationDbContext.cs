using UMS.GROUP.Airport.Booking.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public interface IApplicationDbContext
{
    IQueryable<IdentityUser> Users { get; }

    DbSet<Airport> Airport { get; }

    DbSet<Country> Country { get; }

    DbSet<Plane> Plane { get; }

    DbSet<Flight> Flight { get; }

    DbSet<PassengerBooking> PassengerBooking { get; }

    DbSet<FoodCategory> FoodCategory { get; }

    DbSet<Food> Food { get; }

    DbSet<Promo> Promo { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
