using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record GetAllCustomRoleByIdQuery : IRequest<Result<GetAllCustomRoleByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetCustomRoleByIdQueryHandler : IRequestHandler<GetAllCustomRoleByIdQuery, Result<GetAllCustomRoleByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetCustomRoleByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllCustomRoleByIdQueryDto>> Handle(GetAllCustomRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.CustomRole.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAllCustomRoleByIdQueryDto
                {
                    Id = result.Id,
                    UniqueId = result.UniqueId,
                    RoleName = result.RoleName,
                    RoleDescription = result.RoleDescription,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAllCustomRoleByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
