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

    DbSet<CustomRole> CustomRole { get; }

    DbSet<Restaurant> Restaurant { get; }

    DbSet<RestaurantBooking> RestaurantBooking { get; }

    DbSet<RestaurantOrder> RestaurantOrder { get; }

    DbSet<RestaurantOrderDetail> RestaurantOrderDetail { get; }

    DbSet<RestaurantPayment> RestaurantPayment { get; }

    DbSet<RestaurantTable> RestaurantTable { get; }

    DbSet<RestaurantBookingTable> RestaurantBookingTable { get; }

    DbSet<DraftCartItems> DraftCartItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
