
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class CustomRoles : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateCustomRole, "CreateCustomRole")
            .MapPut(UpdateCustomRole, "UpdateCustomRole")
            .MapGet(GetAllCustomRole, "GetAllCustomRole")
            .MapGet(GetAllCustomRoleById, "GetAllCustomRoleById")
            ;
    }

    public async Task<List<GetAllCustomRoleQueryDto>> GetAllCustomRole(ISender sender, [AsParameters] GetAllCustomRoleQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAllCustomRoleByIdQueryDto>> GetAllCustomRoleById(ISender sender, [AsParameters] GetAllCustomRoleByIdQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateCustomRoleCommandDto>> CreateCustomRole(ISender sender, CreateCustomRoleCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateCustomRoleCommandDto>> UpdateCustomRole(ISender sender, UpdateCustomRoleCommand command)
    {
        return sender.Send(command);
    }

}
