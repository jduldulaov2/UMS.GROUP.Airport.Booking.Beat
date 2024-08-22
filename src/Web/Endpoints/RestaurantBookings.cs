
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class RestaurantOrders : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRestaurantOrder, "CreateRestaurantOrder")
            .MapPut(UpdateRestaurantOrder, "UpdateRestaurantOrder")
            .MapGet(GetAllRestaurantOrder, "GetAllRestaurantOrder")
            .MapGet(GetAllRestaurantOrderById, "GetAllRestaurantOrderById")
            ;
    }

    public async Task<List<GetAllRestaurantOrderQueryDto>> GetAllRestaurantOrder(ISender sender, [AsParameters] GetAllRestaurantOrderQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllRestaurantOrderByIdQueryDto>> GetAllRestaurantOrderById(ISender sender, [AsParameters] GetAllRestaurantOrderByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateRestaurantOrderCommandDto>> CreateRestaurantOrder(ISender sender, CreateRestaurantOrderCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateRestaurantOrderCommandDto>> UpdateRestaurantOrder(ISender sender, UpdateRestaurantOrderCommand command)
    {
        return sender.Send(command);
    }

}
