using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class RestaurantTable : BaseAuditableEntity
{
    public string? TableName { get; set; }

    public string? TableDescription { get; set; }

    public string? TableLocation { get; set; }
}
