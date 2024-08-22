
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class RestaurantBookings : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRestaurantBooking, "CreateRestaurantBooking")
            .MapPut(UpdateRestaurantBooking, "UpdateRestaurantBooking")
            .MapGet(GetAllRestaurantBooking, "GetAllRestaurantBooking")
            .MapGet(GetAllRestaurantBookingById, "GetAllRestaurantBookingById")
            ;
    }

    public async Task<List<GetAllRestaurantBookingQueryDto>> GetAllRestaurantBooking(ISender sender, [AsParameters] GetAllRestaurantBookingQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllRestaurantBookingByIdQueryDto>> GetAllRestaurantBookingById(ISender sender, [AsParameters] GetAllRestaurantBookingByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateRestaurantBookingCommandDto>> CreateRestaurantBooking(ISender sender, CreateRestaurantBookingCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateRestaurantBookingCommandDto>> UpdateRestaurantBooking(ISender sender, UpdateRestaurantBookingCommand command)
    {
        return sender.Send(command);
    }

}
