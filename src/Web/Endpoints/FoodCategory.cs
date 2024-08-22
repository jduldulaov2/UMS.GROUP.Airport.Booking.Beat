
using UMS.GROUP.Airport.Booking.Application.Common.Models;

public class FoodCategory : EndpointGroupBase
{

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateFoodCategory, "CreateFoodCategory")
            .MapPut(UpdateFoodCategory, "UpdateFoodCategory")
            .MapGet(GetAllFoodCategory, "GetAllFoodCategory")
            .MapGet(GetAllFoodCategoryById, "GetAllFoodCategoryById")
            ;
    }


    public async Task<List<GetAllFoodCategoryQueryDto>> GetAllFoodCategory(ISender sender, [AsParameters] GetAllFoodCategoryQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllFoodCategoryByIdQueryDto>> GetAllFoodCategoryById(ISender sender, [AsParameters] GetAllFoodCategoryByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateFoodCategoryCommandDto>> CreateFoodCategory(ISender sender, CreateFoodCategoryCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateFoodCategoryCommandDto>> UpdateFoodCategory(ISender sender, UpdateFoodCategoryCommand command)
    {
        return sender.Send(command);
    }

}
