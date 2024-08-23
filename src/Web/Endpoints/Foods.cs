
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Foods : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateFood, "CreateFood")
            .MapPut(UpdateFood, "UpdateFood")
            .MapGet(GetAllFood, "GetAllFood")
            .MapGet(GetAllFoodByCategoryId, "GetAllFoodByCategoryId")
            .MapGet(GetAllFoodById, "GetAllFoodById")
            ;
    }

    public async Task<List<GetAllFoodQueryDto>> GetAllFood(ISender sender, [AsParameters] GetAllFoodQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetAllFoodByCategoryIdQueryDto>> GetAllFoodByCategoryId(ISender sender, [AsParameters] GetAllFoodCategoryIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllFoodByIdQueryDto>> GetAllFoodById(ISender sender, [AsParameters] GetAllFoodByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateFoodCommandDto>> CreateFood(ISender sender, CreateFoodCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateFoodCommandDto>> UpdateFood(ISender sender, UpdateFoodCommand command)
    {
        return sender.Send(command);
    }

}
