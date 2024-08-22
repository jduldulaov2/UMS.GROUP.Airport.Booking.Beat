using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateCustomRoleCommand : IRequest<Result<CreateCustomRoleCommandDto>>
{
    public string? RoleName { get; init; }

    public string? RoleDescription { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateCustomRoleCommandHandler : IRequestHandler<CreateCustomRoleCommand, Result<CreateCustomRoleCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateCustomRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateCustomRoleCommandDto>> Handle(CreateCustomRoleCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.CustomRole.Where(p => p.RoleName == request.RoleName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new CustomRole();

            entity.RoleName = request.RoleName;

            entity.RoleDescription = request.RoleDescription;

            entity.IsActive = request.IsActive;

            _context.CustomRole.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateCustomRoleCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreateCustomRoleCommandDto
                {

                },
                Message = "Record '" + request.RoleName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}

