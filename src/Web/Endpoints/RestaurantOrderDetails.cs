
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class RestaurantOrderDetails : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRestaurantOrderDetail, "CreateRestaurantOrderDetail")
            .MapPut(UpdateRestaurantOrderDetail, "UpdateRestaurantOrderDetail")
            .MapGet(GetAllRestaurantOrderDetail, "GetAllRestaurantOrderDetail")
            .MapGet(GetAllRestaurantOrderDetailById, "GetAllRestaurantOrderDetailById")
            ;
    }

    public async Task<List<GetAllRestaurantOrderDetailQueryDto>> GetAllRestaurantOrderDetail(ISender sender, [AsParameters] GetAllRestaurantOrderDetailQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllRestaurantOrderDetailByIdQueryDto>> GetAllRestaurantOrderDetailById(ISender sender, [AsParameters] GetAllRestaurantOrderDetailByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateRestaurantOrderDetailCommandDto>> CreateRestaurantOrderDetail(ISender sender, CreateRestaurantOrderDetailCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateRestaurantOrderDetailCommandDto>> UpdateRestaurantOrderDetail(ISender sender, UpdateRestaurantOrderDetailCommand command)
    {
        return sender.Send(command);
    }

}
