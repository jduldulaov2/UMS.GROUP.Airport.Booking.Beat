using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Restaurant : BaseAuditableEntity
{
    public string? RestaurantName { get; set; }

    public string? RestaurantDescription { get; set; }

    public string? RestaurantFullAddress { get; set; }

    public string? RestaurantContactNumber { get; set; }
}
