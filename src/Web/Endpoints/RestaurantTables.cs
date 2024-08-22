
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class RestaurantTables : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateRestaurantTable, "CreateRestaurantTable")
            .MapPut(UpdateRestaurantTable, "UpdateRestaurantTable")
            .MapGet(GetAllRestaurantTable, "GetAllRestaurantTable")
            .MapGet(GetAllRestaurantTableById, "GetAllRestaurantTableById")
            ;
    }

    public async Task<List<GetAllRestaurantTableQueryDto>> GetAllRestaurantTable(ISender sender, [AsParameters] GetAllRestaurantTableQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllRestaurantTableByIdQueryDto>> GetAllRestaurantTableById(ISender sender, [AsParameters] GetAllRestaurantTableByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateRestaurantTableCommandDto>> CreateRestaurantTable(ISender sender, CreateRestaurantTableCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateRestaurantTableCommandDto>> UpdateRestaurantTable(ISender sender, UpdateRestaurantTableCommand command)
    {
        return sender.Send(command);
    }

}
