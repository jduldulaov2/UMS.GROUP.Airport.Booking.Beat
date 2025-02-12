﻿using System.Reflection;
using UMS.GROUP.Airport.Booking.Domain.Entities;
using UMS.GROUP.Airport.Booking.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Airport> Airport => Set<Airport>();

    public DbSet<Country> Country => Set<Country>();

    public DbSet<Plane> Plane => Set<Plane>();

    public DbSet<Flight> Flight => Set<Flight>();

    public DbSet<FoodCategory> FoodCategory => Set<FoodCategory>();

    public DbSet<Food> Food => Set<Food>();

    public DbSet<Promo> Promo => Set<Promo>();

    public DbSet<CustomRole> CustomRole => Set<CustomRole>();

    public DbSet<Restaurant> Restaurant => Set<Restaurant>();

    public DbSet<RestaurantBooking> RestaurantBooking => Set<RestaurantBooking>();

    public DbSet<RestaurantOrder> RestaurantOrder => Set<RestaurantOrder>();

    public DbSet<RestaurantOrderDetail> RestaurantOrderDetail => Set<RestaurantOrderDetail>();

    public DbSet<RestaurantPayment> RestaurantPayment => Set<RestaurantPayment>();

    public DbSet<RestaurantTable> RestaurantTable => Set<RestaurantTable>();

    public DbSet<RestaurantBookingTable> RestaurantBookingTable => Set<RestaurantBookingTable>();

    public DbSet<PassengerBooking> PassengerBooking => Set<PassengerBooking>();

    public DbSet<DraftCartItems> DraftCartItems => Set<DraftCartItems>();


    public DbSet<RestaurantUserLog> RestaurantUserLog => Set<RestaurantUserLog>();

    IQueryable<IdentityUser> IApplicationDbContext.Users => this.Users;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
