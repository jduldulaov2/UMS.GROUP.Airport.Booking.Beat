
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class RestaurantUserLogs : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRestaurantUserLog, "CreateRestaurantUserLog")
            .MapPut(UpdateRestaurantUserLog, "UpdateRestaurantUserLog")
            .MapGet(GetAllRestaurantUserLog, "GetAllRestaurantUserLog")
            .MapGet(GetAllRestaurantUserLogById, "GetAllRestaurantUserLogById")
            ;
    }

    public async Task<List<GetAllRestaurantUserLogQueryDto>> GetAllRestaurantUserLog(ISender sender, [AsParameters] GetAllRestaurantUserLogQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllRestaurantUserLogByIdQueryDto>> GetAllRestaurantUserLogById(ISender sender, [AsParameters] GetAllRestaurantUserLogByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateRestaurantUserLogCommandDto>> CreateRestaurantUserLog(ISender sender, CreateRestaurantUserLogCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateRestaurantUserLogCommandDto>> UpdateRestaurantUserLog(ISender sender, UpdateRestaurantUserLogCommand command)
    {
        return sender.Send(command);
    }

}
