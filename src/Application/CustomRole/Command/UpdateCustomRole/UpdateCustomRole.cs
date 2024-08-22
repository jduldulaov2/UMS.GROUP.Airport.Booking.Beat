using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateCustomRoleCommand : IRequest<Result<UpdateCustomRoleCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? RoleName { get; init; }

    public string? RoleDescription { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateCustomRoleCommandHandler : IRequestHandler<UpdateCustomRoleCommand, Result<UpdateCustomRoleCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateCustomRoleCommandDto>> Handle(UpdateCustomRoleCommand request, CancellationToken cancellationToken)
    {
        var record = _context.CustomRole.FirstOrDefault(item => item.RoleName == request.RoleName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.CustomRole.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {

                entity.RoleName = request.RoleName;

                entity.RoleDescription = request.RoleDescription;

                entity.IsActive = request.IsActive;

                _context.CustomRole.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateCustomRoleCommandDto
                    {
                        Id = entity.UniqueId,
                        UpdatedDate = DateTime.Now,
                    },
                    Message = "Updated successfully.",
                    ResultType = ResultType.Success,
                };
            }
        }
        else
        {
            return new()
            {
                Data = new UpdateCustomRoleCommandDto
                {

                },
                Message = "Record '" + request.RoleName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateCustomRoleCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
