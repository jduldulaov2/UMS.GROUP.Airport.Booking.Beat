
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class DraftCartItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateDraftCartItems, "CreateDraftCartItems")
            .MapPut(UpdateDraftCartItems, "UpdateDraftCartItems")
            .MapGet(GetAllDraftCartItemsByCode, "GetAllDraftCartItemsByCode")
            ;
    }

    public async Task<List<GetAllDraftCartItemsQueryDtoByCode>> GetAllDraftCartItemsByCode(ISender sender, [AsParameters] GetAllDraftCartItemsQuery query)
    {
        return await sender.Send(query);
    }


    public Task<Result<CreateDraftCartItemsCommandDto>> CreateDraftCartItems(ISender sender, CreateDraftCartItemsCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateDraftCartItemsCommandDto>> UpdateDraftCartItems(ISender sender, UpdateDraftCartItemsCommand command)
    {
        return sender.Send(command);
    }

}
