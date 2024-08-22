using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class CustomRole : BaseAuditableEntity
{
    public string? RoleName { get; set; }

    public string? RoleDescription { get; set; }
}
