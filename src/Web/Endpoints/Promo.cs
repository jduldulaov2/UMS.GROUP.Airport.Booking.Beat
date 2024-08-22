
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.PromoCategory.Queries.GetAllPromoCategory;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Promo : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreatePromo, "CreatePromo")
            .MapPut(UpdatePromo, "UpdatePromo")
            .MapGet(GetAllPromo, "GetAllPromo")
            .MapGet(GetAllPromoById, "GetAllPromoById")
            ;
    }

    public async Task<List<GetAllPromoQueryDto>> GetAllPromo(ISender sender, [AsParameters] GetAllPromoQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllPromoByIdQueryDto>> GetAllPromoById(ISender sender, [AsParameters] GetAllPromoByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreatePromoCommandDto>> CreatePromo(ISender sender, CreatePromoCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdatePromoCommandDto>> UpdatePromo(ISender sender, UpdatePromoCommand command)
    {
        return sender.Send(command);
    }

}
