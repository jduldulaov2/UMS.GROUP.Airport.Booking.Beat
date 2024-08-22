using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.CustomRoleCategory.Queries.GetAllCustomRoleCategory;

public record GetAllCustomRoleQuery : IRequest<List<GetAllCustomRoleQueryDto>>
{

}

public class GetAllCustomRoleQueryHandler : IRequestHandler<GetAllCustomRoleQuery, List<GetAllCustomRoleQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCustomRoleQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllCustomRoleQueryDto>> Handle(GetAllCustomRoleQuery request, CancellationToken cancellationToken)
    {
        return await (from CustomRole in _context.CustomRole
                      select new GetAllCustomRoleQueryDto
                      {
                          Id = CustomRole.Id,
                          UniqueId = CustomRole.UniqueId,
                          RoleName = CustomRole.RoleName,
                          RoleDescription = CustomRole.RoleDescription,
                          IsActive = CustomRole.IsActive == null ? true : CustomRole.IsActive

                      }).ToListAsync();
    }
}
