using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.CustomRoleCategory.Queries.GetAllCustomRoleCategory;

public class GetAllCustomRoleQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }

    public bool? IsActive { get; set; }
}
